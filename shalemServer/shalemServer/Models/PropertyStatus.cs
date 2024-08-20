using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class PropertyStatus
    {
        public PropertyStatus()
        {
            AuditProperties = new HashSet<AuditProperty>();
            Properties = new HashSet<Property>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int Index { get; set; }

        public virtual ICollection<AuditProperty> AuditProperties { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
