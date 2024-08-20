using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class View2
    {
        public string UpdatedById { get; set; } = null!;
        public string CreatedById { get; set; } = null!;
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public int PropertyId { get; set; }
        public string? Name { get; set; }
        public string? FullName { get; set; }
        public string ContentType { get; set; } = null!;
        public int IsDeleted { get; set; }
    }
}
