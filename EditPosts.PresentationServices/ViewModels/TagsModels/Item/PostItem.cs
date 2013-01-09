using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditPosts.PresentationServices.ViewModels.TagsModels.Item
{
    public class PostItem
    {
        public PostItem(string name, string body, int postId)
        {
            Name = name;
            Body = body;
            PostId = postId;
        }
        public string Name { get; set; }
        public string Body { get; set; }
        public int PostId { get; set; }
    }
}
