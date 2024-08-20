using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class Mana
    {
        public Mana()
        {
            Properties = new HashSet<Property>();
            PropertyOlds = new HashSet<PropertyOld>();
        }

        public int Id { get; set; }
        public string? UpdatedById { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int ManaNumber { get; set; }
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
        public int PropCount { get; set; }
        public string? Status { get; set; }

        public virtual AspNetUser? CreatedBy { get; set; }
        public virtual Department Department { get; set; } = null!;
        public virtual AspNetUser? UpdatedBy { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<PropertyOld> PropertyOlds { get; set; }
    }
}
