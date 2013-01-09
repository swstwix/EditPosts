using EditPosts.Domain.Models;
using EditPosts.PresentationServices.ViewModels.TagsModels.Item;
using System.Collections.Generic;
using System.Linq;

namespace EditPosts.PresentationServices.ViewModels.TagsModels
{
    public class TagIndexModel
    {
        public TagIndexModel(string tagName, IEnumerable<Post> posts)
        {
            this.TagName = tagName;
            PostItem = posts.Select(x => new PostItem(x.Body, x.Name, x.Id)).ToArray();
        }

        public string TagName { get; set; }

        public IEnumerable<PostItem> PostItem { get; set; }
    }
}