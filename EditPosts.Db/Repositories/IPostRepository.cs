using System.Collections.Generic;
using EditPosts.Domain;

namespace EditPosts.Db.Repositories
{
    public interface IPostRepository : IEntityRepository<Post>
    {
        IEnumerable<Post> LatestPosts { get; }
        IEnumerable<Post> MostPopularPosts { get; }
        void IncHitCount(int postId);
    }
}