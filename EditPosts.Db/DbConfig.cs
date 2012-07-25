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
                                "Data Source=WD-SERVER-5;User ID=TestData;Password=TestData")).Mappings(
                                    m => m.FluentMappings.AddFromAssemblyOf<PostMap>()).
                            BuildConfiguration().AddXmlFile(@"C:\Users\f.demesh\documents\visual studio 2010\Projects\EditPosts\EditPosts.Db\Tag.hbm.xml");
                if (_config == null)
                    throw new InvalidOperationException("NHibernate configuration is null");
                return _config;
            }
            set { throw new NotImplementedException(); }
        }
    }
}