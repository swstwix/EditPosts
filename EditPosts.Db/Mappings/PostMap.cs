using System;
using EditPosts.Domain.Models;
using FluentNHibernate.Mapping;

namespace EditPosts.Db.Mappings
{
    public sealed class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Table("Posts");
            Id(p => p.Id);
            Map(p => p.PostDate);
            Map(p => p.HitCount);
            Map(p => p.Name);
            Map(p => p.Body).Length(Int32.MaxValue - 1);
            HasManyToMany(p => p.Tags).Table("Posts_Tags").Cascade.AllDeleteOrphan().Not.LazyLoad().AsSet();
        }
    }
}