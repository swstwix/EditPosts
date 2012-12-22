using System.Collections.Generic;
using System.Linq;
using EditPosts.Domain.Models;
using EditPosts.Domain.Repositories;
using EditPosts.PresentationServices.ViewModels.TagsModels;
using EditPosts.PresentationServices.ViewModels.TagsModels.TagItem;

namespace EditPosts.PresentationServices.Services.Concret
{
    public class TagPresentationService : ITagPresentationService
    {
        private readonly ITagRepository tagRepository;

        public TagPresentationService(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        #region ITagPresentationService Members

        public TagCloudModel LoadTagCloudModel()
        {
            return new TagCloudModel (
                                        tagRepository.All().ToList<Tag>().Select
                                        (t => new TagCloudItemModel(t.Name, t.Posts.Sum(p => p.HitCount)))
                                     );
        }

        public IEnumerable<string> LoadTagNamesContains(string term)
        {
            return tagRepository.All().Select(t => t.Name).Where(n => n.Contains(term));
        }

        public TagIndexModel LoadTagIndexModel(string name)
        {
            return new TagIndexModel {Tag = tagRepository.Get(name)};
        }

        #endregion
    }
}