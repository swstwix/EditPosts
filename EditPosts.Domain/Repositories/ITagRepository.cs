using EditPosts.Domain.Models;
using System.Collections.Generic;

namespace EditPosts.Domain.Repositories
{
    public interface ITagRepository : IRepository
    {
        string AvailableTags();
        void DeleteUnusedTags();
        Tag Get(string name);

        IEnumerable<Tag> AllTags();

        IEnumerable<string> LoadTagsNamesContails(string term);
    }
}