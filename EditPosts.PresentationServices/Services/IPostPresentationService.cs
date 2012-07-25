using EditPosts.PresentationServices.ViewModels.MixedModels;
using EditPosts.PresentationServices.ViewModels.PostsModels;

namespace EditPosts.PresentationServices.Services
{
    public interface IPostPresentationService : IBasePresentationService
    {
        PostIndexModel LoadPostIndexModel();

        TagCloudWithBestPostsModel LoadTagCloudWithBestPostsModel();

        PostDetailsViewModel LoadPostDetailsViewModel(int id);
    }
}