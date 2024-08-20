using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class Job
    {
        public Job()
        {
            RoleJobs = new HashSet<RoleJob>();
            UserJobs = new HashSet<UserJob>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<RoleJob> RoleJobs { get; set; }
        public virtual ICollection<UserJob> UserJobs { get; set; }
    }
}
