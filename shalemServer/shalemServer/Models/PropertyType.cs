using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class PropertyType
    {
        public PropertyType()
        {
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }
    }
}
