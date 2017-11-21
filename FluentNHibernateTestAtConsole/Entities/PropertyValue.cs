using System;
using FluentNHibernate.Mapping;

namespace FluentNHibernateTestAtConsole.Entities
{
  public class PropertyValue
  {
    public virtual Guid Guid { get; protected set; }

    public virtual Guid Property { get; set; }

    public virtual Guid Parent { get; set; }

    public virtual string Value { get; set; }

    public virtual DateTime LastModified { get; set; }

    public override string ToString()
    {
      return string.Format("PropertyValue: UUID: {0}, Property uuid: {1}, Parent: {2}, Value: {3}, Last modified: {4}",
        Guid,
        Property,
        Parent,
        Value,
        LastModified);
    }
  }
}
