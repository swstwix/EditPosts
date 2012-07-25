using System;
using EditPosts.Db.Repositories;
using EditPosts.PresentationServices.ViewModels.MixedModels;
using EditPosts.PresentationServices.ViewModels.PostsModels;

namespace EditPosts.PresentationServices.Services.Concret
{
    public class PostPresentationService : IPostPresentationService
    {
        private readonly IPostRepository postRepository;
        private readonly ITagRepository tagRepository;

        public PostPresentationService(IPostRepository postRepository, ITagRepository tagRepository)
        {
            this.postRepository = postRepository;
            this.tagRepository = tagRepository;
        }

        #region IPostPresentationService Members

        public PostIndexModel LoadPostIndexModel()
        {
            return new PostIndexModel {LatestPosts = postRepository.LatestPosts};
        }

        public TagCloudWithBestPostsModel LoadTagCloudWithBestPostsModel()
        {
            return new TagCloudWithBestPostsModel
                       {AllTags = tagRepository.Query(), BestPosts = postRepository.MostPopularPosts};
        }

        public PostDetailsViewModel LoadPostDetailsViewModel(int id)
        {
            return new PostDetailsViewModel() {Post = postRepository.Get(id)};
        }

        #endregion
    }
}