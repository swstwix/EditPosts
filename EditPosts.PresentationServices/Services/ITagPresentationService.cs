using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EditPosts.PresentationServices.ViewModels.TagsModels;

namespace EditPosts.PresentationServices.Services
{
    public interface ITagPresentationService : IBasePresentationService
    {
        TagIndexModel LoadTagIndexModel(string name);
    }
}
