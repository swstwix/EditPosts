using System.Collections.Generic;
using EditPosts.Domain.Models;
using EditPosts.PresentationServices.ViewModels.TagsModels.TagItem;

namespace EditPosts.PresentationServices.ViewModels.TagsModels
{
    public class TagCloudModel
    {
        public IEnumerable<TagCloudItemModel> AllTags { get; set; }
    }
}