using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class Department
    {
        public Department()
        {
            Manas = new HashSet<Mana>();
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }

        public virtual ICollection<Mana> Manas { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
