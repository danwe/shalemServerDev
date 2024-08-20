using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class Filebackup
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
        public bool IsDeleted { get; set; }
    }
}
