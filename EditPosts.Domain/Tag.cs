using System.Collections.Generic;
using System.Linq;

namespace EditPosts.Domain
{
    public class Tag
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual int Rating
        {
            get { return Posts.Sum(x => x.HitCount); }
        }
    }
}