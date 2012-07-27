using System.Collections.Generic;
using System.Linq;

namespace EditPosts.Domain.Models
{
    public class Tag
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public override int GetHashCode()
        {
            return string.Concat("Tag", Name).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var tagObject = obj as Tag;
            if (tagObject == null)
                return false;
            return this.GetHashCode() == obj.GetHashCode();
        }
    }
}