using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;

namespace FluentNHibernateTestAtConsole.Entities
{
  public class UserMap : ClassMap<User>
  {
    public UserMap()
    {
      Table("tblUser");

      Id(x => x.Guid)
        .Column("uuid")
        .GeneratedBy.GuidComb()
        .Not.Nullable();

      Map(x => x.LastModified)
        .Column("lastmodified")
        .Not.Nullable();

      //HasManyToMany(x => x.Properties)
      //     .Cascade.All()
      //     .Table("UserProperties");
    }
  }
}
