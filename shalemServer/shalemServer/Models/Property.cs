using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class Property
    {
        public Property()
        {
            Areas = new HashSet<Area>();
            AuditProperties = new HashSet<AuditProperty>();
            Events = new HashSet<Event>();
            Files = new HashSet<File>();
        }

        public int Id { get; set; }
        public string? UpdatedById { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int DepartmentId { get; set; }
        public int PropertyTypeId { get; set; }
        public string? ModedId { get; set; }
        public string? SartatId { get; set; }
        public int PropertyStatusId { get; set; }
        public string BuildingSite { get; set; } = null!;
        public string? PropertySite { get; set; }
        public string? FloorNumber { get; set; }
        public string? HouseNumber { get; set; }
        public int? IdentityNumber { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone1 { get; set; }
        public string? Phone2 { get; set; }
        public string? Phone3 { get; set; }
        public int? BuildingYear { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? ContractNumber { get; set; }
        public decimal OldChargeArea { get; set; }
        public decimal OldMeasureArea { get; set; }
        public string Street { get; set; } = null!;
        public string? Contact2 { get; set; }
        public string BuildingNumber { get; set; } = null!;
        public bool? IsMedida { get; set; }
        public string? Mivnan { get; set; }
        public string? Neighborhood { get; set; }
        public string? UseType { get; set; }
        public DateTime? MeasureEnd { get; set; }
        public DateTime? MeasureStart { get; set; }
        public int? ManaId { get; set; }
        public string? MedidaComment { get; set; }
        public string? PropertyDetailes { get; set; }
        public string? Comments { get; set; }
        public string? Contact3 { get; set; }
        public bool? IsDeleted { get; set; }
        public string? NameOrder { get; set; }
        public string? OrderNumber { get; set; }
        public string? Phone4 { get; set; }

        public virtual AspNetUser? CreatedBy { get; set; }
        public virtual Department Department { get; set; } = null!;
        public virtual Mana? Mana { get; set; }
        public virtual AspNetUser? Moded { get; set; }
        public virtual PropertyStatus PropertyStatus { get; set; } = null!;
        public virtual PropertyType PropertyType { get; set; } = null!;
        public virtual AspNetUser? Sartat { get; set; }
        public virtual AspNetUser? UpdatedBy { get; set; }
        public virtual BuildingSoker? BuildingSoker { get; set; }
        public virtual FloorSoker? FloorSoker { get; set; }
        public virtual PropertySoker? PropertySoker { get; set; }
        public virtual ICollection<Area> Areas { get; set; }
        public virtual ICollection<AuditProperty> AuditProperties { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<File> Files { get; set; }
    }
}
