using System.Collections.Generic;
using EditPosts.Domain.Models;

namespace EditPosts.Domain.Services
{
    public interface IPostRepository : IEntityRepository<Post>
    {
        IEnumerable<Post> LatestPosts { get; }
        IEnumerable<Post> MostPopularPosts { get; }
        void IncHitCount(int postId);
    }
}