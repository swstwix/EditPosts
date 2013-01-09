using System.Collections.Generic;
using EditPosts.Domain.Models;

namespace EditPosts.Domain.Repositories
{
    public interface IPostRepository : IRepository
    {
        IEnumerable<Post> LatestPosts { get; }
        IEnumerable<Post> MostPopularPosts { get; }
        void IncHitCount(int postId);
        void Delete(int postId);
        IEnumerable<Post> AllPosts();
        Post Get(int postId);
        void Save(Post post);

        IEnumerable<Post> GetByTagName(string tagName);
    }
}