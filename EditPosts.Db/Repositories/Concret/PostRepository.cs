using System.Collections.Generic;
using System.Linq;
using EditPosts.Domain;
using NHibernate;

namespace EditPosts.Db.Repositories.Concret
{
    public class PostRepository : EntityRepository<Post>, IPostRepository
    {
        public PostRepository(ISession session)
            : base(session)
        {
        }

        public IEnumerable<Post> LatestPosts
        {
            get { return Query().OrderByDescending(p => p.PostDate).Take(5); }
        }

        public IEnumerable<Post> MostPopularPosts
        {
            get { return Query().OrderByDescending(p => p.HitCount).Take(3); }
        }

        public void IncHitCount(int postId)
        {
            Post post = Get(postId);
            post.HitCount++;
            Update(post);
        }
    }
}