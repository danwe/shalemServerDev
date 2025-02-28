namespace shalemServer.Models.Dto
{

    public class PropertyDto
    {
        public string? BuildingNumber { get; set; } = string.Empty;
        public string? BuildingSite { get; set; } = string.Empty;
        public int? BuildingYear { get; set; } = 0;
        public string? Comments { get; set; } = string.Empty;
        public string? Contact1 { get; set; } = string.Empty;
        public string? Contact2 { get; set; } = string.Empty;
        public string? ContractNumber { get; set; } = string.Empty;
        public string? CreatedByID { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string? DeliveryAddress { get; set; } = string.Empty;
        public string? Department { get; set; } = string.Empty;
        public int DepartmentId { get; set; } = 0;

        public string? FirstName { get; set; } = string.Empty;
        public string? FloorNumber { get; set; } = string.Empty;
        public string? HouseNumber { get; set; } = string.Empty;
        public string? IdentityNumber { get; set; } = string.Empty;
        public bool? IsMedida { get; set; } = false;
        public string? LastName { get; set; } = string.Empty;
        public string? Mana { get; set; } = string.Empty;
        public DateTime? MeasureEnd { get; set; }
        public DateTime? MeasureStart { get; set; }
        public string? MedidaComment { get; set; } = string.Empty;
        public string? Moded { get; set; } = string.Empty;
        public string? NameMazmin { get; set; } = string.Empty;
        public string? Note { get; set; } = string.Empty;
        public int? OldChargeArea { get; set; } = 0;
        public int? OldMeasureArea { get; set; } = 0;
        public string? Phone1 { get; set; } = string.Empty;
        public string? Phone2 { get; set; } = string.Empty;
        public string? Phone3 { get; set; } = string.Empty;
        public string? PropertySite { get; set; } = string.Empty;
        public int PropertyStatusId { get; set; } = 0;
        public string? PropertyStatus { get; set; } = string.Empty;

        public int PropertyTypeId { get; set; } = 0;
        public string? PropertyType { get; set; } = string.Empty;

        public string? Sartat { get; set; } = string.Empty;
        public string? Street { get; set; } = string.Empty;
        public string?       UpdatedByID { get; set; } = string.Empty;
        public IFormFile? UploadFiles { get; set; } // For file uploads
    }

}
