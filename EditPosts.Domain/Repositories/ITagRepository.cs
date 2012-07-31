using EditPosts.Domain.Models;

namespace EditPosts.Domain.Repositories
{
    public interface ITagRepository : IEntityRepository<Tag>
    {
        string AvailableTags();
        void DeleteUnusedTags();
        Tag Get(string name);
    }
}