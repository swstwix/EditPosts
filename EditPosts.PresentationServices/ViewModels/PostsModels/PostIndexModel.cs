using System.Collections.Generic;
using EditPosts.Domain.Models;

namespace EditPosts.PresentationServices.ViewModels.PostsModels
{
    public class PostIndexModel
    {
        public IEnumerable<Post> LatestPosts { get; set; }
    }
}
