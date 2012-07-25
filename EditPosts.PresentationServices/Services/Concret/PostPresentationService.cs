using EditPosts.Db.Repositories;
using EditPosts.PresentationServices.ViewModels.PostsModels;
using EditPosts.PresentationServices.ViewModels.TagsModels;
using System.Linq;
using EditPosts.PresentationServices.ViewModels.TagsModels.TagItem;

namespace EditPosts.PresentationServices.Services.Concret
{
    public class PostPresentationService : IPostPresentationService
    {
        private readonly IPostRepository postRepository;

        public PostPresentationService(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        #region IPostPresentationService Members

        public PostIndexModel LoadPostIndexModel()
        {
            return new PostIndexModel {LatestPosts = postRepository.LatestPosts};
        }

        public PostDetailsModel LoadPostDetailsViewModel(int id)
        {
            return new PostDetailsModel {Post = postRepository.Get(id)};
        }

        public PostAdminModel LoadPostAdminModel()
        {
            return new PostAdminModel(){Posts = postRepository.Query()};
        }

        #endregion
    }
}