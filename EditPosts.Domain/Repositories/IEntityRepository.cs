using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace EditPosts.Domain.Repositories
{
    public interface IEntityRepository<T> : IRepository
    {
        IQueryable<T> All();
        void Delete(T entity);
        void Delete(int id);
        T Get(int id);
        void Save(T entity);
        void Update(T entity);
    }
}