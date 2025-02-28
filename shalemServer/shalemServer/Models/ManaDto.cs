namespace shalemServer.Models
{
    public class ManaDto
    {
        public int Id { get; set; }
        public string? UpdatedById { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int ManaNumber { get; set; }
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public bool? IsDeleted { get; set; }
        public int PropCount { get; set; }

        public int CityId { get; set; }
        public Department Department { get; set; } = null!;

        public string? Status { get; set; }
    }
}