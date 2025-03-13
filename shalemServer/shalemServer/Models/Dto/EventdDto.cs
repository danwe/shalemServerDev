namespace shalemServer.Models.Dto
{

    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; } // Event name
        public DateTime StartDate { get; set; } // When the event starts
        public DateTime EndDate { get; set; } // When the event ends
        public DateTime CreatedAt { get; set; } // When the event was created
        public DateTime UpdatedAt { get; set; } // When the event was last updated
        public DateTime Timestamp { get; set; } // General timestamp (possibly for logging)
        public DateTime ScheduledDate { get; set; } // The planned date for the event

        // Navigation Properties
        public int CreatedById { get; set; }
        public AspNetUser CreatedBy { get; set; } // Reference to the user who created the event

        public int EventTypeId { get; set; }
        public EventType EventType { get; set; } // Reference to the event type

        public int PropertyId { get; set; }
        public Property Property { get; set; } // Reference to the associated property
        

    }
}
