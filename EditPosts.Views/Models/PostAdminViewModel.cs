using System.Collections.Generic;
using System.Linq;
using EditPosts.Domain.Models;

namespace EditPosts.Views.Models
{
    public class PostAdminViewModel
    {
        public IEnumerable<Post> Posts { get; set; }

        public int PostsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int BeginIndex()
        {
            return (CurrentPage - 1)*PostsPerPage;
        }

        public int EndIndex()
        {
            int ans = CurrentPage*PostsPerPage - 1;
            //check when it is last page
            if (ans > Posts.Count())
                ans = Posts.Count();
            return ans;
        }

        public bool IsFirstPage()
        {
            return CurrentPage == 1;
        }

        public bool IsLastPage()
        {
            return EndIndex() == Posts.Count();
        }
    }
}