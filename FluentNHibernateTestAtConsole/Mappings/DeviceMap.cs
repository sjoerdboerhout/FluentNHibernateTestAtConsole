using FluentNHibernate.Mapping;
using FluentNHibernateTestAtConsole.Entities;

namespace FluentNHibernateTestAtConsole.Mappings
{
  public class DeviceMap : ClassMap<Device>
  {
    public DeviceMap()
    {
      Table("device");

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

      HasManyToMany(x => x.Properties)
        .Cascade.All()
        .Fetch.Join()
        .Table("property_device")
        .ParentKeyColumn("property_id")
        .ChildKeyColumn("device_id")
        .LazyLoad();
    }
  }
}
