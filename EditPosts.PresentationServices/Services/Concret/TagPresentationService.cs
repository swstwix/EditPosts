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
        private readonly IPostRepository postRepository;

        public TagPresentationService(ITagRepository tagRepository, IPostRepository postRepository)
        {
            this.tagRepository = tagRepository;
            this.postRepository = postRepository;
        }

        #region ITagPresentationService Members

        public TagCloudModel LoadTagCloudModel()
        {
            return new TagCloudModel (
                                        tagRepository.AllTags().Select
                                        (t => new TagCloudItemModel(t.Name, tagRepository.CountAssignedPostsFor(t.Id)))
                                     );
        }

        public IEnumerable<string> LoadTagNamesContains(string term)
        {
            return tagRepository.LoadTagsNamesContails(term);
        }

        public TagIndexModel LoadTagIndexModel(string name)
        {
            return new TagIndexModel(name, postRepository.GetByTagName(name));
        }

        #endregion
    }
}