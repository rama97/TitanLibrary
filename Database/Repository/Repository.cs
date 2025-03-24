using Database.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System.Data.SqlClient;
using System.Text;

namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity,new()
    {

        private readonly string _connectionString;
        private readonly string _tableName;

        public Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Database");
            _tableName = typeof(TEntity).Name; // Assumes table name matches entity name
        }

        public async Task<IEnumerable<TEntity>> GetAll(string Search, string[] Match)
        {
            List<TEntity> entities = new List<TEntity>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                StringBuilder stringBuilder = new StringBuilder($"SELECT * FROM {_tableName}");
                if (!string.IsNullOrEmpty(Search) && Match.Length != 0)
                {
                    stringBuilder.Append(" WHERE ");
                    var st = string.Join("OR", Match.Select(a => $"({a} LIKE '%{Search}%')").ToList());
                    stringBuilder.Append(st);
                }

                using (SqlCommand cmd = new SqlCommand(stringBuilder.ToString(), conn))
                {
                    using (SqlDataReader reader =await  cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                           TEntity entity = MapToEntity(reader);
                            entities.Add(entity);
                        }
                    }
                }
            }
            return entities;
        }

        public async Task<TEntity> GetById(long id)
        {
           TEntity entity = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM [{_tableName}] WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            entity = MapToEntity(reader);
                        }
                    }
                }
            }
            return entity;
        }

        public async Task AddAsync(TEntity entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var properties = typeof(TEntity).GetProperties().Where(a => a.Name != "Id");
                var columns = string.Join(", ", properties.Select(p => p.Name));
                var parameters = string.Join(", ", properties.Select(p => "@" + p.Name));

                string query = $"INSERT INTO [{_tableName}] ({columns}) VALUES ({parameters})";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    foreach (var prop in properties)
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity) ?? DBNull.Value);
                    }
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Update(TEntity entity)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var properties = typeof(TEntity).GetProperties();
                var setClause = string.Join(", ", properties.Where(a => a.Name != "Id").Select(p => $"{p.Name} = @{p.Name}"));

                string query = $"UPDATE {_tableName} SET {setClause} WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    foreach (var prop in properties)
                    {
                        cmd.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity) ?? DBNull.Value);
                    }
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand($"DELETE FROM {_tableName} WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
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