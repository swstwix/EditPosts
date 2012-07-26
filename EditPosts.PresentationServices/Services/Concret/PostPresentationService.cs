using System.Linq;
using EditPosts.Db.Repositories;
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
            return new PostIndexModel
                       {
                           LatestPosts = postRepository.LatestPosts
                               .Select(p => new PostPreviewModel
                                                {
                                                    Body = p.Body,
                                                    PostId = p.Id,
                                                    Name = p.Name
                                                })
                       };
        }

        public PostDetailsModel LoadPostDetailsViewModel(int id)
        {
            return new PostDetailsModel { Post = postRepository.Get(id) };
        }

        public PostAdminModel LoadPostAdminModel()
        {
            return new PostAdminModel { Posts = postRepository.Query() };
        }

        public PostEditViewModel LoadPostEditViewModel(int postId, bool isFirstView)
        {
            if (isFirstView)
                postRepository.IncHitCount(postId);
            return new PostEditViewModel()
                       {
                           Post = postRepository.Get(postId),
                           AvailableTags = tagRepository.AvailableTags()
                       };
        }

        #endregion IPostPresentationService Members
    }
}