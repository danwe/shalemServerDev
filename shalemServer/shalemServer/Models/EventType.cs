﻿using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
