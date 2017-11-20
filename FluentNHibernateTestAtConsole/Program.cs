using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateTestAtConsole.Entities;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Tool.hbm2ddl;
using Configuration = NHibernate.Cfg.Configuration;

namespace FluentNHibernateTestAtConsole
{
  class Program
  {
    private const string DatabaseFilePath = @"database.db";

    static void Main(string[] args)
    {
      List<User> Users = new List<User>();
      List<Device> Devices = new List<Device>();

      // create our NHibernate session factory
      var sessionFactory = CreateSessionFactory(DatabaseFilePath);

      using (var session = sessionFactory.OpenSession())
      {
        if (!session.Transaction.IsActive)
        {
          // populate the database
          using (var transaction = session.BeginTransaction())
          {
            Console.WriteLine("Ready to execute a query!");


            User user = new User()
            {
              LastModified = DateTime.Now
            };
            session.SaveOrUpdate(user);
            Console.WriteLine("Save user: " + user);


            Device device = new Device()
            {
              Name = "X",
              LastModified = DateTime.Now
            };
            session.SaveOrUpdate(device);
            Console.WriteLine("Save user: " + device);


            Property property = new Property()
            {
              Name = "X",
              Value = "Y",
              LastModified = DateTime.Now
            };
            session.SaveOrUpdate(property);
            Console.WriteLine("Save property: " + property);


            transaction.Commit();
            Console.WriteLine("Transaction completed.");
          }

          using (var transaction = session.BeginTransaction())
          {
            var users = from user in session.Query<User>()
                        select user;
            foreach (var user in users)
            {
              Console.WriteLine("User: {0}", user);
            }

            var devices = from device in session.Query<Device>()
                        select device;
            foreach (var device in devices)
            {
              Console.WriteLine("Device: {0}", device);
            }

            var properties = from property in session.Query<Property>()
                          select property;
            foreach (var property in properties)
            {
              Console.WriteLine("Property: {0}", property);
            }

          }
        }
        else
        {
          Console.WriteLine("a transaction is already active... ");
        }

        Console.ReadKey();
      }
    }


    private static ISessionFactory CreateSessionFactory(string databasePath)
    {
      return Fluently.Configure()
          .Database(SQLiteConfiguration.Standard
              .UsingFile(databasePath)
              .ShowSql)
          .Mappings(m =>
          m.FluentMappings.
            AddFromAssembly(Assembly.GetExecutingAssembly()))

        .ExposeConfiguration(BuildSchema)
        .BuildSessionFactory();
    }

    private static void BuildSchema(Configuration config)
    {
      try
      {
        if (File.Exists(DatabaseFilePath))
          File.Delete(DatabaseFilePath);

        // this NHibernate tool takes a configuration (with mapping info in)
        // and exports a database schema from it
        new SchemaExport(config)
            .Create(true, true);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }
  }
}
