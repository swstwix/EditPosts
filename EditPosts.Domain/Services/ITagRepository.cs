using EditPosts.Domain.Models;

namespace EditPosts.Domain.Services
{
    public interface ITagRepository : IEntityRepository<Tag>
    {
        string AvailableTags();
        void DeleteUnusedTags();
        Tag Get(string name);
    }
}