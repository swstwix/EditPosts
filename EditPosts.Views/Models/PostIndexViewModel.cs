using System.Collections.Generic;
using EditPosts.Domain;

namespace EditPosts.Views.Models
{
    public class PostIndexViewModel
    {
        public IEnumerable<Post> LatestPosts { get; set; }
    }
}