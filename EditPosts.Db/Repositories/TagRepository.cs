using System.Linq;
using System.Text;
using EditPosts.Domain.Models;
using EditPosts.Domain.Repositories;
using NHibernate;

namespace EditPosts.Db.Repositories
{
    public class TagRepository : EntityRepository<Tag>, ITagRepository
    {
        public TagRepository(ISession session)
            : base(session)
        {
        }

        #region ITagRepository Members

        public string AvailableTags()
        {
            var builder2 = new StringBuilder();

            foreach (var name in All().Select(x => x.Name).ToList<string>())
                builder2.AppendFormat("\"{0}\",", name);

            return builder2.ToString();
        }

        public void DeleteUnusedTags()
        {
            foreach (var tag in All().Where(t => !t.Posts.Any()))
            {
                Delete(tag);
            }
        }

        public Tag Get(string name)
        {
            // fuck you, nhibernate !!
            var id = All().Where(x => x.Name == name).SingleOrDefault().Id;
            return Get(id);
        }

        #endregion
    }
}