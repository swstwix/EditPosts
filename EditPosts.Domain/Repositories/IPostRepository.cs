using System.Collections.Generic;
using EditPosts.Domain.Models;

namespace EditPosts.Domain.Repositories
{
    public interface IPostRepository : IRepository
    {
        IEnumerable<Post> LatestPosts();
        IEnumerable<Post> MostPopularPosts();
        void IncHitCount(int postId);
        void Delete(int postId);
        IEnumerable<Post> AllPosts();
        Post Get(int postId);
        void Save(Post post);

        IEnumerable<Post> GetByTagName(string tagName);
        Post GetWithTags(int postId);
    }
}