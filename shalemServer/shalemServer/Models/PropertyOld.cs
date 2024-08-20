using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class PropertyOld
    {
        public int Id { get; set; }
        public int SiteId { get; set; }
        public int ManaId { get; set; }
        public string? Site { get; set; }
        public string? Department { get; set; }
        public string? ManaName { get; set; }

        public virtual Mana Mana { get; set; } = null!;
    }
}
