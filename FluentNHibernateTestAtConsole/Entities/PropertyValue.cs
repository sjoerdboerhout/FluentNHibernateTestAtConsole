using System;
using System.Collections.Generic;

namespace FluentNHibernateTestAtConsole.Entities
{
  public class PropertyValue
  {
    public virtual Guid Id { get; protected set; }

    public virtual Guid Parent { get; set; }

    public virtual string Value { get; set; }

    public virtual DateTime LastModified { get; set; }
  }
}
