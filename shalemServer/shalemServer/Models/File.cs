using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class File
    {
        public int Id { get; set; }
        public string? UpdatedById { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int PropertyId { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public string? ContentType { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual AspNetUser? CreatedBy { get; set; }
        public virtual Property Property { get; set; } = null!;
        public virtual AspNetUser? UpdatedBy { get; set; }
    }
}
