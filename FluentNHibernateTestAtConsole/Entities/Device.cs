using System;
using System.Collections.Generic;
using FluentNHibernate.Mapping;

namespace FluentNHibernateTestAtConsole.Entities
{
  public class Device
  {
    public virtual Guid Guid { get; set; }

    public virtual string Name { get; set; }

    public virtual DateTime LastModified { get; set; }

    public virtual List<Property> Properties { get; set; } = new List<Property>();

    public override string ToString()
    {
      return string.Format("\n-UUID: {0}\n-Last modified: {1}\n-Nr of properties: {2}\n",
                            Guid,
                            LastModified,
                            Properties.Count);
    }
  }
}
