using System;
using FluentNHibernate.Mapping;

namespace FluentNHibernateTestAtConsole.Entities
{
  public class PropertyValueMap : ClassMap<PropertyValue>
  {
    public PropertyValueMap()
    {
      Table("tblPropertyValues");

      Id(x => x.Guid)
        .Column("uuid")
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
