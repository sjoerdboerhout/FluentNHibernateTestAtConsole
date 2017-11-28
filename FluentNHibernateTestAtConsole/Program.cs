using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateTestAtConsole.Entities;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Linq;
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

            Property property = new Property()
            {
              Name = "X",
              LastModified = DateTime.Now
            };
            property.AddValue(new PropertyValue()
            {
              Parent = property.Guid,
              Property = property.Guid,
              LastModified = DateTime.Now.AddMinutes(-1),
              Value = "Y"
            });
            property.AddValue(new PropertyValue()
            {
              Parent = property.Guid,
              Property = property.Guid,
              LastModified = DateTime.Now,
              Value = "Z"
            });
            session.SaveOrUpdate(property);
            Console.WriteLine("Save property: " + property);

            User user = new User()
            {
              LastModified = DateTime.Now
            };
            //user.AddProperty(property);
            session.SaveOrUpdate(user);
            Console.WriteLine("Save user: " + user);


            Device device = new Device()
            {
              Name = "X",
              LastModified = DateTime.Now
            };
//            session.SaveOrUpdate(device);
            Console.WriteLine("Save device: " + device);


            transaction.Commit();
            Console.WriteLine("Transaction completed.");
          }

          session.Flush();

          using (var transaction = session.BeginTransaction())
          {
            var users = (from user in session.Query<User>()
                        select user)
              .OrderBy( x => x.LastModified).ToList();

            foreach (var user in users)
            {
              Console.WriteLine("User: {0}", user);
            }

            var devices = (from device in session.Query<Device>()
                        select device)
              .OrderBy(x => x.LastModified).ToList();
            foreach (var device in devices)
            {
              Console.WriteLine("Device: {0}", device);
            }

            var properties = (from property in session.Query<Property>()
                          select property)
              .OrderBy(x => x.Name).ToList();
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
              //.InMemory()
              .UsingFile(databasePath)
              .ShowSql)
          .Mappings(m =>
          //m.AutoMappings
          //  .Add(AutoMap.AssemblyOf<Property>())
          //  .Add(AutoMap.AssemblyOf<PropertyValue>())
          //  .Add(AutoMap.AssemblyOf<Device>())
          //  .Add(AutoMap.AssemblyOf<User>()))
          m.FluentMappings.
            AddFromAssembly(Assembly.GetExecutingAssembly()))

        .ExposeConfiguration(BuildSchema)
#if DEBUG
        .Diagnostics(d => d.Enable())
        .Diagnostics(d => d.OutputToConsole())
#endif
        .BuildSessionFactory();
    }

    private static void BuildSchema(Configuration config)
    {
      try
      {
        if (File.Exists(DatabaseFilePath))
          File.Delete(DatabaseFilePath);

        // Only update scheme
        //new SchemaUpdate(config)
        //  .Execute(true, true);

        // Drop tables and create a new scheme
        new SchemaExport(config)
          .Create(true, true);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
      }
    }
  }
}

