using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditPosts.PresentationServices.ViewModels.TagsModels.TagItem
{
    public class TagCloudItemModel
    {
        public TagCloudItemModel(string name, int rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name { get; private set; }

        public int Rating { get; private set; }
    }
}
