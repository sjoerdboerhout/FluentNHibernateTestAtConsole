using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Mapping;

namespace FluentNHibernateTestAtConsole.Entities
{
  public class PropertyMap : ClassMap<Property>
  {
    public PropertyMap()
    {
      Table("tblProperties");

      Id(x => x.Guid)
        .Column("uuid")
        .Not.Nullable();

      Map(x => x.Name)
        .Column("name")
        .Not.Nullable();

      Map(x => x.LastModified)
        .Column("lastmodified")
        .Not.Nullable();

      Map(x => x.Value)
        .Column("value")
        .Not.Nullable();

      //HasMany<PropertyValue>(x => x.Values)
      //  .Cascade.All();

    }
  }
}
