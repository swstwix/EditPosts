using System.Linq;
using EditPosts.Db.Repositories;
using EditPosts.PresentationServices.ViewModels.PostsModels;

namespace EditPosts.PresentationServices.Services.Concret
{
    public class PostPresentationService : IPostPresentationService
    {
        private readonly IPostRepository postRepository;

        public PostPresentationService(IPostRepository postRepository, ITagRepository tagRepository)
        {
            this.postRepository = postRepository;
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

        #endregion IPostPresentationService Members
    }
}