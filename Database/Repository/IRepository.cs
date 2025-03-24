using Database.Models;

namespace Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll(string Search, string[] Match);

        Task<TEntity> GetById(long id);

        Task AddAsync(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(int id);
    }
}