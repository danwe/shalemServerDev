using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string? UpdatedById { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? PropertyId { get; set; }
        public string? UserEventId { get; set; }
        public int EventTypeId { get; set; }
        public string? Description { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string? Title { get; set; }
        public string? HokerId { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual AspNetUser? CreatedBy { get; set; }
        public virtual EventType EventType { get; set; } = null!;
        public virtual AspNetUser? Hoker { get; set; }
        public virtual Property? Property { get; set; }
        public virtual AspNetUser? UpdatedBy { get; set; }
        public virtual AspNetUser? UserEvent { get; set; }
    }
}
