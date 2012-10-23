using System;
using EditPosts.Db.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;

namespace EditPosts.Db
{
    public class DbConfig
    {
        private static Configuration config;

        public static Configuration Configuration
        {
            get
            {
                if (config == null)
                    config =
                        Fluently.Configure().Database(
                            MsSqlConfiguration.MsSql2008.ConnectionString(
                                "Data Source=WD-SERVER-5;Persist Security Info=True;User ID=TestData;Password=TestData")).Mappings(
                                    m => m.FluentMappings.AddFromAssemblyOf<PostMap>()).
                            BuildConfiguration();
                if (config == null)
                    throw new InvalidOperationException("NHibernate configuration is null");
                return config;
            }
            set { throw new NotImplementedException(); }
        }
    }
}