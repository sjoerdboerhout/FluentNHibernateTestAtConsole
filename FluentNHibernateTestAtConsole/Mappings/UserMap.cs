using FluentNHibernate.Mapping;
using FluentNHibernateTestAtConsole.Entities;

namespace FluentNHibernateTestAtConsole.Mappings
{
  public class UserMap : ClassMap<User>
  {
    public UserMap()
    {
      Table("user");

      Id(x => x.Guid)
        .Column("uuid")
        .GeneratedBy.GuidComb()
        .Not.Nullable();

      Map(x => x.LastModified)
        .Column("lastmodified")
        .Not.Nullable();

      //HasManyToMany(x => x.Properties)
      //  .Cascade.All()
      //  .Fetch.Join()
      //  .Table("property_user")
      //  .ParentKeyColumn("property_id")
      //  .ChildKeyColumn("user_id")
      //  .LazyLoad();
    }
  }
}
