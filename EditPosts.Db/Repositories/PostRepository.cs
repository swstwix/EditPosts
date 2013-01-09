using System.Collections.Generic;
using System.Linq;
using EditPosts.Domain.Models;
using EditPosts.Domain.Repositories;
using NHibernate;

namespace EditPosts.Db.Repositories
{
    public class PostRepository : EntityRepository<Post>, IPostRepository
    {
        public PostRepository(ISession session)
            : base(session)
        {
        }

        #region IPostRepository Members

        public IEnumerable<Post> LatestPosts
        {
            get { return All().OrderByDescending(p => p.PostDate).Take(5).ToList<Post>(); }
        }

        public IEnumerable<Post> MostPopularPosts
        {
            get { return All().OrderByDescending(p => p.HitCount).Take(3).ToList<Post>(); }
        }

        public void IncHitCount(int postId)
        {
            Post post = Get(postId);
            if (post == default(Post))
                return;
            post.HitCount++;
            Update(post);
        }

        #endregion


        public IEnumerable<Post> AllPosts()
        {
            return All().AsEnumerable<Post>();
        }
    }
}