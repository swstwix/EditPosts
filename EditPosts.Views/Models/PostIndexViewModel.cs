using System.Collections.Generic;
using EditPosts.Domain.Models;

namespace EditPosts.Views.Models
{
    public class PostIndexViewModel
    {
        public IEnumerable<Post> LatestPosts { get; set; }
    }
}