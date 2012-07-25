using System.Collections.Generic;
using EditPosts.Domain.Models;

namespace EditPosts.PresentationServices.ViewModels.MixedModels
{
    public class TagCloudWithBestPostsModel
    {
        public IEnumerable<Tag> AllTags { get; set; }

        public IEnumerable<Post> BestPosts { get; set; }
    }
}