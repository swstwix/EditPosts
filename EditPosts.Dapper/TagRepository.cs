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
    public class TagRepository : ITagRepository
    {
        private string connectionString;

        public TagRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string AvailableTags()
        {
            var builder2 = new StringBuilder();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                connection.Query<string>("select name from #Tag");
                builder2.AppendFormat("\"{0}\",", "");
            }

            return builder2.ToString();
        }

        public void DeleteUnusedTags()
        {
            throw new NotImplementedException();
        }

        public Tag Get(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> AllTags()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> LoadTagsNamesContails(string term)
        {
            throw new NotImplementedException();
        }
    }
}
