using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class RoleJob
    {
        public int Id { get; set; }
        public string Role { get; set; } = null!;
        public int JobId { get; set; }

        public virtual Job Job { get; set; } = null!;
    }
}
