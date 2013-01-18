using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using EditPosts.Domain.Models;
using EditPosts.Domain.Repositories;

namespace EditPosts.Dapper
{
    public class PostRepository : IPostRepository
    {
        private readonly SqlConnection connection;

        public PostRepository(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public IEnumerable<Post> LatestPosts()
        {
            return connection.Query<Post>("select top 3 * from Posts order by PostDate desc").ToArray();
        }

        public IEnumerable<Post> MostPopularPosts()
        {
            return connection.Query<Post>("select top 5 * from Posts order by HitCount desc").ToArray();
        }

        public void IncHitCount(int postId)
        {
            connection.Execute("update Posts set HitCount = HitCount + 1 where id = @postId", new { postId });
        }

        public void Delete(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> AllPosts()
        {
            return connection.Query<Post>("select * from Posts");
        }

        public Post Get(int postId)
        {
            return connection.Query<Post>("select * from Posts where id = @id", new { id = postId }).SingleOrDefault();
        }

        public void Save(Post post)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetByTagName(string tagName)
        {
            return
                connection.Query<Post>(
                    "select * from Posts where id in (select Post_Id from Posts_Tags join Tags t on t.name = @tagName)",
                    new { tagName }).ToArray();
        }

        public Post GetWithTags(int postId)
        {
            var res = connection.Query<Post, Tag, Post>("select * from Posts p join Posts_Tags on p.id = post_id join Tags t on t.id = tag_id where p.id = @id", (post, tag) =>
            {
                if (post.Tags == null)
                    post.Tags = new List<Tag>();
                post.Tags.Add(tag);
                return post;
            }, new { id = postId }, splitOn: "post_id").GroupBy(x => x.Id, post => ).;

            return connection.Query<Tag, Post, Post>("select * from Posts p join Posts_Tags on p.id = post_id join Tags t on t.id = tag_id where p.id = @id", (tag, post) =>
            {
                if (post.Tags == null)
                    post.Tags = new List<Tag>();
                post.Tags.Add(tag);
                return post;
            }, new {id = postId})
            .SingleOrDefault();
        }
    }
}
