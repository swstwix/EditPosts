using System.Linq;
using System.Text;
using EditPosts.Domain.Models;
using EditPosts.Domain.Services;
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

            foreach (Tag tag in All())
                builder2.AppendFormat("\"{0}\",", tag.Name);

            return builder2.ToString();
        }

        public void DeleteUnusedTags()
        {
            foreach (var tag in Query().Where(t => !t.Posts.Any()))
            {
                Delete(tag);
            }
        }

        public Tag Get(string name)
        {
            try
            {
                return Query().Single(t => t.Name.Equals(name));
            }
            catch
            {
                return default(Tag);
            }
        }

        #endregion
    }
}