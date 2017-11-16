using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;

namespace FluentNHibernateTestAtConsole
{
  class Program
  {
    private const string DatabaseFilePath = @"database.db";

    static void Main(string[] args)
    {
      // create our NHibernate session factory
      var sessionFactory = CreateSessionFactory(DatabaseFilePath);

      using (var session = sessionFactory.OpenSession())
      {
        // populate the database
        using (var transaction = session.BeginTransaction())
        {
        }
      }
    }

    private static ISessionFactory CreateSessionFactory(string databasePath)
    {
      return Fluently.Configure()
          .Database(SQLiteConfiguration.Standard
              .UsingFile(databasePath))
          .Mappings(m =>
              m.FluentMappings.AddFromAssemblyOf<Program>())
          .ExposeConfiguration(BuildSchema)
          .BuildSessionFactory();
    }

    private static void BuildSchema(Configuration config)
    {
      // this NHibernate tool takes a configuration (with mapping info in)
      // and exports a database schema from it
      new SchemaExport(config)
          .Create(false, true);
    }
  }
}
