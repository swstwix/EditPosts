using EditPosts.Dapper;
using EditPosts.Domain.Models;
using EditPosts.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace EditPosts.Dapper
{
    public class TagRepository : ITagRepository, IDisposable
    {
        private readonly SqlConnection connection;

        public TagRepository(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public string AvailableTags()
        {
            var builder2 = new StringBuilder();

                connection.Open();
                connection.Query<string>("select name from Tags");
                builder2.AppendFormat("\"{0}\",", "");

            return builder2.ToString();
        }

        public void DeleteUnusedTags()
        {
                var unusedTagIds = connection.Query<int>(
                     "select id from #Tags where not exists (select * from Posts_Tags where Tag_Id = id)");
                connection.Query("delete from Tags where id in @unusedTagIds", new {unusedTagIds});
        }

        public Tag Get(string name)
        {
           return connection.Query<Tag>("select * from Tags where name = @name", new {name}).Single();
        }

        public IEnumerable<Tag> AllTags()
        {
            return connection.Query<Tag>("select * from Tags").ToArray();
        }

        public IEnumerable<string> LoadTagsNamesContails(string term)
        {
            return connection.Query<string>("select name from tags where name likes '%@term%'", new { term }).ToArray();
        }

        public int CountAssignedPostsFor(int tagId)
        {
            return connection.Query<int>("select sum(hitcount) from Posts_Tags join posts on id=post_id where tag_id = @tagId", new { tagId }).Single();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}
