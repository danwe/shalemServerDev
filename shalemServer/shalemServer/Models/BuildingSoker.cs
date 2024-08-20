using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class BuildingSoker
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
        public bool IsPinatit { get; set; }
        public string? Pinatit { get; set; }
        public string? Floor { get; set; }
        public string? FloorOnKarka { get; set; }
        public string? FloorDownKaraka { get; set; }
        public bool IsComany { get; set; }
        public string? Comany { get; set; }
        public string? Mezahe { get; set; }
        public string? Phones { get; set; }
        public string? Gisha { get; set; }
        public string? Maalit1 { get; set; }
        public string? Maalit2 { get; set; }
        public string? Gim { get; set; }
        public string? Mtbahon { get; set; }
        public string? Lobby { get; set; }
        public string? AreaShirut { get; set; }
        public string? Miklat { get; set; }
        public string? MaderegotnIn { get; set; }
        public string? MaderegotOut { get; set; }
        public string? Pool { get; set; }
        public string? Shirutim { get; set; }
        public bool Images { get; set; }
        public string? Comments { get; set; }
        public string? NameModed { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsAreaShirut { get; set; }
        public bool? IsGim { get; set; }
        public bool? IsGisha { get; set; }
        public bool? IsLobby { get; set; }
        public bool? IsMaalit1 { get; set; }
        public bool? IsMaalit2 { get; set; }
        public bool? IsMaderegotOut { get; set; }
        public bool? IsMaderegotnIn { get; set; }
        public bool? IsMiklat { get; set; }
        public bool? IsMtbahon { get; set; }
        public bool? IsPool { get; set; }
        public bool? IsShirutim { get; set; }
        public string? DateInModed { get; set; }
        public string? HourInModed { get; set; }
        public string? KesherNatzig { get; set; }
        public string? NameNatzig { get; set; }
        public string? SignModed { get; set; }
        public string? SignNatzig { get; set; }

        public virtual AspNetUser? CreatedBy { get; set; }
        public virtual Property Property { get; set; } = null!;
        public virtual AspNetUser? UpdatedBy { get; set; }
    }
}
