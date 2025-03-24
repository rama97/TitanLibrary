using System.Data;
using System.Data.SqlClient;

namespace Repository
{
    public class SPRepository<TEntity> : ISPRepository<TEntity> where TEntity : new()
    {

        public async Task<List<TEntity>> ExecuteDataReaderSP(string SPName, SqlParameter[] Parameters)
        {
            string Paramstr = string.Join(", ", Parameters.Select(p => p.ParameterName));
            List<TEntity> entities = new List<TEntity>();

            using (SqlConnection conn = new SqlConnection(Tools.Config.SqlDarabaseConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SPName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(Parameters);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TEntity entity = MapToEntity(reader);
                            entities.Add(entity);
                        }
                    }
                }
            }
            var paramObj = Parameters.ToArray();
            return entities;
        }

        public async Task<List<TEntity>> ExecuteSP(string SPName, SqlParameter[] Parameters)
        {
            string Paramstr = string.Join(", ", Parameters.Select(p => p.ParameterName));
            List<TEntity> entities = new List<TEntity>();

            using (SqlConnection conn = new SqlConnection(Tools.Config.SqlDarabaseConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(SPName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddRange(Parameters);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
            var paramObj = Parameters.ToArray();
            return entities;
        }

        private TEntity MapToEntity(SqlDataReader reader)
        {
            TEntity entity = new TEntity();
            foreach (var prop in typeof(TEntity).GetProperties())
            {
                if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                {
                    prop.SetValue(entity, reader[prop.Name]);
                }
            }
            return entity;
        }
    }
}
