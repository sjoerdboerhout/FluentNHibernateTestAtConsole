using FluentNHibernate.Mapping;
using FluentNHibernateTestAtConsole.Entities;

namespace FluentNHibernateTestAtConsole.Mappings
{
  public class PropertyMap : ClassMap<Property>
  {
    public PropertyMap()
    {
      Table("properties");

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

      //Map(x => x.Value)
      //  .Column("value")
      //  .Not.Nullable();

      //HasMany<PropertyValue>(x => x.Values)
      //  .Cascade.All()
      //  .Table("tblPropertyValues");

      HasManyToMany(x => x.Values)
        .Table("propertyvalues")
        .ParentKeyColumn("property_uuid")
        .ChildKeyColumn("propertyvalue_uuid")
        .Cascade.All();
    }
  }
}
