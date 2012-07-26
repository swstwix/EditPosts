using EditPosts.PresentationServices.ViewModels.PostsModels;

namespace EditPosts.PresentationServices.Services
{
    public interface IPostPresentationService : IBasePresentationService
    {
        PostIndexModel LoadPostIndexModel();

        PostDetailsModel LoadPostDetailsViewModel(int id);

        PostAdminModel LoadPostAdminModel();

        PostEditViewModel LoadPostEditViewModel(int postId, bool isFirstView);
    }
}