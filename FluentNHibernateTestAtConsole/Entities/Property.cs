using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace FluentNHibernateTestAtConsole.Entities
{
  public class Property
  {
    public virtual Guid Guid { get; protected set; }

    public virtual string Name { get; set; }

    public virtual string Value { get; set; }

    public virtual DateTime LastModified { get; set; }

    /*
    public string Value
    {
      get
      {
        if (Values.Count > 0)
          return Values[0].Value;
        else
          return "";
      }
    }
    */

    //public virtual List<PropertyValue> Values { get; set; }

    public override string ToString()
    {
      return string.Format("\n-UUID: {0}\n-Name: {1}\n-Value: {2}\n-Last modified: {3}\n",
        Guid,
        Name,
        Value,
        LastModified);
    }
  }
}
