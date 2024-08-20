using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class FloorSoker
    {
        public int Id { get; set; }
        public string? UpdatedById { get; set; }
        public string? CreatedById { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int PropertyId { get; set; }
        public string? Mazmina { get; set; }
        public string? DateOrder { get; set; }
        public string? Address { get; set; }
        public string? HouseNumber { get; set; }
        public string? FloorNumber { get; set; }
        public string? FloorNumberActive { get; set; }
        public bool IsTimroon { get; set; }
        public string? Timroon { get; set; }
        public bool IsMirpesetKoma { get; set; }
        public string? MirpesetKoma { get; set; }
        public bool IsMirpesetKoma1 { get; set; }
        public string? MirpesetKoma1 { get; set; }
        public bool IsMisdaronKoma { get; set; }
        public string? Misdaron { get; set; }
        public bool IsMisdaronKoma1 { get; set; }
        public string? MisdaronKoma1 { get; set; }
        public bool IsKitchen1 { get; set; }
        public string? Kitchen1 { get; set; }
        public bool IsKitchen2 { get; set; }
        public string? Kitchen2 { get; set; }
        public bool IsKitchen3 { get; set; }
        public string? Kitchen3 { get; set; }
        public bool IsLobby1 { get; set; }
        public string? Lobby1 { get; set; }
        public bool IsLobby2 { get; set; }
        public string? Lobby2 { get; set; }
        public bool IsMamak1 { get; set; }
        public string? Mamak1 { get; set; }
        public bool IsMamak2 { get; set; }
        public string? Mamak2 { get; set; }
        public bool IsMaderegotOut { get; set; }
        public string? MaderegotOut { get; set; }
        public bool IsMaderegot { get; set; }
        public string? Maderegot { get; set; }
        public bool IsShirutim1 { get; set; }
        public string? Shirutim1 { get; set; }
        public bool IsShirutim2 { get; set; }
        public string? Shirutim2 { get; set; }
        public bool IsAreaShirut { get; set; }
        public string? AreaShirut { get; set; }
        public bool Images { get; set; }
        public string? NameModed { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DateInModed { get; set; }
        public string? HourInModed { get; set; }
        public string? KesherNatzig { get; set; }
        public string? NameNatzig { get; set; }
        public string? SignModed { get; set; }
        public string? SignNatzig { get; set; }
        public string? Comments { get; set; }

        public virtual AspNetUser? CreatedBy { get; set; }
        public virtual Property Property { get; set; } = null!;
        public virtual AspNetUser? UpdatedBy { get; set; }
    }
}
