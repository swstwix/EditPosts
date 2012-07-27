using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EditPosts.Domain.Models
{
    public class Post
    {
        public virtual ICollection<Tag> Tags { get; set; }

        public virtual int Id { get; set; }

        [StringLength(255), Required]
        public virtual string Name { get; set; }

        public virtual string Body { get; set; }

        public virtual DateTime PostDate { get; set; }

        public virtual int HitCount { get; set; }

        public override int GetHashCode()
        {
            return string.Concat("Post", Name, Body, PostDate, HitCount).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var postObject = obj as Post;
            if (postObject == null)
                return false;
            return this.GetHashCode() == postObject.GetHashCode();
        }
    }
}