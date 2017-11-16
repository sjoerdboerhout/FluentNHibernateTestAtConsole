using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentNHibernateTestAtConsole.Entities
{
  public class Device
  {
    public virtual Guid Id { get; protected set; }

    public virtual string Name { get; set; }

    public virtual DateTime LastModified { get; set; }

    public virtual List<Property> Properties { get; set; }
  }
}
