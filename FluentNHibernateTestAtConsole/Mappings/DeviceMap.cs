using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace FluentNHibernateTestAtConsole.Entities
{
  public class DeviceMap : ClassMap<Device>
  {
    public DeviceMap()
    {
      Table("tblDevice");

      Id(x => x.Guid)
        .Column("uuid")
        .GeneratedBy.GuidComb()
        .Not.Nullable();

      Map(x => x.Name)
        .Column("name")
        .Not.Nullable();

      Map(x => x.LastModified)
        .Column("lastmodified")
        .Not.Nullable();

      //HasManyToMany(x => x.Properties)
      //     .Cascade.All()
      //     .Table("DeviceProperties");
    }
  }
}
