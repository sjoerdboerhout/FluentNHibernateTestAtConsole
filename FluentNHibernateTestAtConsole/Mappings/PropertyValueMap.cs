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

      ////Doesn't work yet and not sure if really needed
      //References(x => x.PropertyId)
      //  .Column("property_uuid")
      //  .Cascade.All();
      ////  .Not.Nullable();

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
