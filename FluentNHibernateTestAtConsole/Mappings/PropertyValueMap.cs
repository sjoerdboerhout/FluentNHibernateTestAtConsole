using FluentNHibernate.Mapping;
using FluentNHibernateTestAtConsole.Entities;

namespace FluentNHibernateTestAtConsole.Mappings
{
  public class PropertyValueMap : ClassMap<PropertyValue>
  {
    public PropertyValueMap()
    {
      Table("property_value");

      Id(x => x.Guid)
        .Column("uuid")
        .GeneratedBy.GuidComb()
        .Not.Nullable();

      //Map(x => x.Property)
      //  .Column("property_uuid")
      //  .Not.Nullable();

      Map(x => x.Parent)
        .Column("parent_uuid")
        .Not.Nullable();

      Map(x => x.LastModified)
        .Column("lastmodified")
        .Not.Nullable();

      Map(x => x.Value)
        .Column("value");
    }
  }
}
