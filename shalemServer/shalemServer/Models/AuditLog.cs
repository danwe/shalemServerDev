using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class AuditLog
    {
        public int Id { get; set; }
        public string? TableName { get; set; }
        public string? Column { get; set; }
        public DateTime DateChanged { get; set; }
        public string? NewValue { get; set; }
        public string? OldValue { get; set; }
        public string? Pkid { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
    }
}
