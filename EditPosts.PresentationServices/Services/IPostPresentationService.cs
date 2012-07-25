using EditPosts.PresentationServices.ViewModels.PostsModels;
using EditPosts.PresentationServices.ViewModels.TagsModels;

namespace EditPosts.PresentationServices.Services
{
    public interface IPostPresentationService : IBasePresentationService
    {
        PostIndexModel LoadPostIndexModel();

        PostDetailsModel LoadPostDetailsViewModel(int id);

        PostAdminModel LoadPostAdminModel();
    }
}