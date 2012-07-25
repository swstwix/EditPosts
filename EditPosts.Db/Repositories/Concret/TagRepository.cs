using System.Linq;
using System.Text;
using EditPosts.Domain.Models;
using NHibernate;

namespace EditPosts.Db.Repositories.Concret
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
            foreach (Tag tag in Query())
            {
                if (tag.Posts.Count == 0)
                    Delete(tag.Id);
            }
        }

        public Tag Get(string name)
        {
            return Query().Single(t => t.Name.Equals(name));
        }

        #endregion
    }
}