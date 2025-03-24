using System.Data.SqlClient;

namespace Repository
{
    public  interface ISPRepository<TEntity>
    {
        Task<List<TEntity>> ExecuteDataReaderSP(string SPName, SqlParameter[] Parameters);

        Task<List<TEntity>> ExecuteSP(string SPName, SqlParameter[] Parameters);
    }
}
