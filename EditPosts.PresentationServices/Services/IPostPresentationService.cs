using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditPosts.PresentationServices.ViewModels.PostsModels;

namespace EditPosts.PresentationServices.Services
{
    public interface IPostPresentationService : IBasePresentationService
    {
        PostIndexModel LoadPostIndexModel();
    }
}
