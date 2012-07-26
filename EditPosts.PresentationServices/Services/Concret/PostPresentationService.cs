using System;
using System.Collections.ObjectModel;
using System.Linq;
using EditPosts.Db.Repositories;
using EditPosts.Domain.Models;
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
            return new PostDetailsModel {Post = postRepository.Get(id)};
        }

        public PostAdminModel LoadPostAdminModel()
        {
            return new PostAdminModel {Posts = postRepository.Query()};
        }

        public PostEditViewModel LoadPostEditViewModel(int postId, bool isFirstView)
        {
            if (isFirstView)
                postRepository.IncHitCount(postId);
            Post post = postRepository.Get(postId) ?? new Post
                                                          {
                                                              PostDate = DateTime.Now,
                                                              HitCount = 1,
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
            var tagNames = postEditViewModel.Tags.Split(',').Where(s => !string.IsNullOrWhiteSpace(s));
            foreach (string tagName in tagNames)
            {
                var dbtag = tagRepository.Get(tagName);
                if (dbtag != null)
                    if (!dbtag.Posts.Contains(post))
                        dbtag.Posts.Add(post);
                post.Tags.Add(dbtag ?? new Tag
                                           {
                                               Name = tagName, 
                                               Posts = new Collection<Post>(new Post[] {post})
                                           });
            }
            postRepository.Save(post);
        }

        public void DeletePost(int postId)
        {
            postRepository.Delete(postId);
        }

        #endregion
    }
}