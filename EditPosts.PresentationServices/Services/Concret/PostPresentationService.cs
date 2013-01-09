using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using EditPosts.Domain.Models;
using EditPosts.Domain.Repositories;
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

        public void DeletePost(int postId)
        {
            postRepository.Delete(postId);
            tagRepository.DeleteUnusedTags();
        }

        public PostAdminModel LoadPostAdminModel()
        {
            return new PostAdminModel { Posts = postRepository.AllPosts() };
        }

        public PostDetailsModel LoadPostDetailsViewModel(int id)
        {
            return new PostDetailsModel { Post = postRepository.Get(id) };
        }

        public PostEditViewModel LoadPostEditViewModel(int postId, bool isFirstView)
        {
            if (isFirstView)
                postRepository.IncHitCount(postId);
            Post post = postRepository.Get(postId) ?? new Post
                                                          {
                                                              PostDate = DateTime.Now,
                                                              HitCount = 0,
                                                              Id = 0,
                                                              Body = string.Empty,
                                                              Name = "New post",
                                                              Tags = new Collection<Tag>(),
                                                          };
            return new PostEditViewModel
                       {
                           Body = post.Body,
                           Date = post.PostDate,
                           Name = post.Name,
                           Tags = string.Concat(post.Tags.Select(tag => string.Concat(tag.Name, ", "))),
                           HitCount = post.HitCount,
                           Id = post.Id
                       };
        }

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
        public void SavePostEditViewModel(PostEditViewModel postEditViewModel)
        {
            Post post = postRepository.Get(postEditViewModel.Id) ?? new Post
                                                                        {
                                                                            PostDate = DateTime.Now,
                                                                            HitCount = 1,
                                                                            Id = 0,
                                                                            Body = string.Empty,
                                                                            Name = "New post",
                                                                            Tags = new Collection<Tag>(),
                                                                        };
            post.Name = postEditViewModel.Name;
            post.Body = postEditViewModel.Body;
            post.Tags.Clear();
            postEditViewModel.Tags = postEditViewModel.Tags ?? string.Empty; 
            var tagNames = postEditViewModel.Tags.Split(',').Select(s => s.Replace(" ", string.Empty)).Where(s => !string.IsNullOrWhiteSpace(s));
            foreach (string tagName in tagNames)
            {
                var tag = tagRepository.Get(tagName) ?? new Tag() { Name = tagName };
                post.Tags.Add(tag);
            }
            postRepository.Save(post);
            tagRepository.DeleteUnusedTags();
        }
        #endregion
    }
}