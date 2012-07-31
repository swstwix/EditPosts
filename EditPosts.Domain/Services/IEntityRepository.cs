using System.Linq;

namespace EditPosts.Domain.Services
{
    public interface IEntityRepository<T> : IRepository
    {
        IQueryable<T> All();
        void Delete(T entity);
        void Delete(int id);
        T Get(int id);
        IQueryable<T> Query();
        void Save(T entity);
        void Update(T entity);
    }
}