using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class Area
    {
        public int Id { get; set; }
        public string? UpdatedById { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public decimal ChargeArea { get; set; }
        public decimal MeasureArea { get; set; }
        public string? ContractNumber { get; set; }
        public string? InstallationNumber { get; set; }
        public int PropertyId { get; set; }
        public string? AreaCode { get; set; }
        public string? PropertyUseType { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual AspNetUser? CreatedBy { get; set; }
        public virtual Property Property { get; set; } = null!;
        public virtual AspNetUser? UpdatedBy { get; set; }
    }
}
