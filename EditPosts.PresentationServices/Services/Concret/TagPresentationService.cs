using EditPosts.Db.Repositories;
using EditPosts.PresentationServices.ViewModels.TagsModels;

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

        public TagIndexModel LoadTagIndexModel(string name)
        {
            return new TagIndexModel {Tag = tagRepository.Get(name)};
        }

        #endregion
    }
}