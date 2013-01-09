using EditPosts.Domain.Models;
using FluentNHibernate.Mapping;

namespace EditPosts.Db.Mappings
{
    public sealed class TagMap : ClassMap<Tag>
    {
        public TagMap()
        {
            Table("Tags");
            Id(t => t.Id);
            Map(t => t.Name);
        }
    }
}