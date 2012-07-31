using System.Collections.Generic;
using System.Linq;
using EditPosts.Domain.Services;
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
            return new TagCloudModel
                       {
                           AllTags = tagRepository.Query().Select(t => new TagCloudItemModel()
                                                                           {
                                                                               Name = t.Name,
                                                                               Rating = t.Posts.Where(p => p.Tags.Any(it => it.Id == t.Id)).Sum(p => p.HitCount)
                                                                           })
                       };
        }

        public IEnumerable<string> LoadTagNamesContains(string term)
        {
            return tagRepository.Query().Select(t => t.Name).Where(n => n.Contains(term));
        }

        public TagIndexModel LoadTagIndexModel(string name)
        {
            return new TagIndexModel {Tag = tagRepository.Get(name)};
        }

        #endregion
    }
}