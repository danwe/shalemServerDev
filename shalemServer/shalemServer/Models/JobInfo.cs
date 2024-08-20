using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class JobInfo
    {
        public int Id { get; set; }
        public string? Department { get; set; }
        public string? Name { get; set; }
        public string? Role { get; set; }
        public int Comment { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
    }
}
