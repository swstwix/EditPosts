using System;
using System.Linq;
using System.Text;
using EditPosts.Domain;

namespace EditPosts.Views.Models
{
    public class PostDetailsViewModel
    {
        private string tag;

        public Post Post { get; set; }

        public String Tags
        {
            get
            {
                if (tag == null)
                {
                    var builder = new StringBuilder();

                    if (Post.Tags == null || !Post.Tags.Any())
                    {
                        builder.Append(";");
                    }
                    else
                    {
                        builder.AppendFormat("{0}", Post.Tags.ElementAt(0).Name);
                        for (int i = 1; i < Post.Tags.Count; i++)
                        {
                            builder.AppendFormat(";{0}", Post.Tags.ElementAt(i).Name);
                        }
                    }
                    tag = builder.ToString();
                }
                return tag;
            }
            set { tag = value; }
        }

        public String AvailableTags { get; set; }
    }
}