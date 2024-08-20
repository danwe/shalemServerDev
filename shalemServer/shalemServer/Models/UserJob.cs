using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class UserJob
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; } = null!;
        public int JobId { get; set; }

        public virtual AspNetUser ApplicationUser { get; set; } = null!;
        public virtual Job Job { get; set; } = null!;
    }
}
