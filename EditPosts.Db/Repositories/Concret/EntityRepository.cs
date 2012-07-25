using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace EditPosts.Db.Repositories.Concret
{
    public class EntityRepository<T> : IEntityRepository<T>
    {
        protected readonly ISession Session;

        public EntityRepository(ISession session)
        {
            Session = session;
        }

        public IQueryable<T> All()
        {
            return Query();
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
            return Session.Get<T>(id);
        }

        public IQueryable<T> Query()
        {
            return Session.Query<T>();
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
    }
}