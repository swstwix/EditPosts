using System.Linq;
using EditPosts.Domain.Repositories;
using NHibernate;
using NHibernate.Linq;

namespace EditPosts.Db.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        protected readonly ISession Session;

        public EntityRepository(ISession session)
        {
            Session = session;
        }

        #region IEntityRepository<T> Members

        public IQueryable<T> All()
        {
            return Session.Query<T>();
        }

        public void Delete(T entity)
        {
            Session.Delete(entity);
            Session.Flush();
        }

        public void Delete(int id)
        {
            var entity = Session.Load<T>(id);
            Delete(entity);
        }

        public T Get(int id)
        {
            try
            {
                return Session.Get<T>(id);
            }
            catch
            {
                return default(T);
            }
        }

        public void Save(T entity)
        {
            Session.Save(entity);
            Session.Flush();
        }

        public void Update(T entity)
        {
            Session.Update(entity);
            Session.Flush();
        }

        #endregion
    }
}