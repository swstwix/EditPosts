using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EditPosts.Domain
{
    public class Post
    {
        public virtual ICollection<Tag> Tags { get; set; }

        #region IPost Members

        public virtual int Id { get; set; }

        [StringLength(255), Required]
        public virtual string Name { get; set; }

        public virtual string Body { get; set; }

        public virtual DateTime PostDate { get; set; }

        public virtual int HitCount { get; set; }

        #endregion IPost Members
    }
}