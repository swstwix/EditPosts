using EditPosts.PresentationServices.ViewModels.TagsModels;

namespace EditPosts.PresentationServices.Services
{
    public interface ITagPresentationService : IBasePresentationService
    {
        TagIndexModel LoadTagIndexModel(string name);

        TagCloudModel LoadTagCloudModel();
    }
}