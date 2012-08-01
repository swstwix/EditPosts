using System;
using EditPosts.Db.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;

namespace EditPosts.Db
{
    public class DbConfig
    {
        private static Configuration _config;

        public static Configuration Configuration
        {
            get
            {
                if (_config == null)
                    _config =
                        Fluently.Configure().Database(
                            MsSqlConfiguration.MsSql2008.ConnectionString(
                                "Data Source=.\\SQLEXPRESS;AttachDbFilename=\"C:\\Users\\Twix\\Documents\\Visual Studio 2010\\Projects\\EditPosts\\EditPosts\\EditPosts.Views\\App_Data\\Database1.mdf\";Integrated Security=True;User Instance=True")).Mappings(
                                    m => m.FluentMappings.AddFromAssemblyOf<PostMap>()).
                            BuildConfiguration();
                if (_config == null)
                    throw new InvalidOperationException("NHibernate configuration is null");
                return _config;
            }
            set { throw new NotImplementedException(); }
        }
    }
}