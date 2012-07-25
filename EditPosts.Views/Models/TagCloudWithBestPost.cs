using System.Collections.Generic;
using EditPosts.Domain;

namespace EditPosts.Views.Models
{
    public class TagCloudWithBestPost
    {
        public IEnumerable<Tag> AllTags { get; set; }

        public IEnumerable<Post> BestPosts { get; set; }
    }
}