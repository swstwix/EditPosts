using System.Collections.Generic;
using EditPosts.Domain.Models;

namespace EditPosts.PresentationServices.ViewModels.PostsModels
{
    public class PostAdminModel
    {
        public IEnumerable<Post> Posts { get; set; }
    }
}