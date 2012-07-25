using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EditPosts.PresentationServices.ViewModels.PostsModels
{
    public class PostPreviewModel
    {
        public String Name { get; set; }

        public int PostId { get; set; }

        public string Body { get; set; }
    }
}
