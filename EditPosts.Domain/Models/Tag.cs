using System.Collections.Generic;
using System.Linq;

namespace EditPosts.Domain.Models
{
    public class Tag
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}