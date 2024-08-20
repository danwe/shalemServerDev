using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class PropertySoker
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
        public bool Nimdad { get; set; }
        public bool Sarvan { get; set; }
        public bool Sagur { get; set; }
        public bool Neheras { get; set; }
        public bool Pail { get; set; }
        public bool NoPail { get; set; }
        public bool Empty { get; set; }
        public bool NoRaouy { get; set; }
        public bool Shiputs { get; set; }
        public bool Harisa { get; set; }
        public string? BuissnesName { get; set; }
        public string? BuissnesNumber { get; set; }
        public bool Dira { get; set; }
        public bool Misrad { get; set; }
        public bool Mchsan { get; set; }
        public bool Hanut { get; set; }
        public bool Parking { get; set; }
        public string? PhoneNumber { get; set; }
        public string? CodeShimush { get; set; }
        public string? TeurShimush { get; set; }
        public string? ShimushDescription { get; set; }
        public bool Images { get; set; }
        public string? MchzikName { get; set; }
        public bool NoYadua { get; set; }
        public bool IsOwner { get; set; }
        public bool IsTenant { get; set; }
        public bool IsPolesh { get; set; }
        public bool IsKey { get; set; }
        public bool Isbk { get; set; }
        public string? ActiveMchzikName { get; set; }
        public string? MisparMezahe { get; set; }
        public string? Zika { get; set; }
        public string? DateHahezaka { get; set; }
        public string? OwnerName { get; set; }
        public string? AreaHiuv { get; set; }
        public string? AreaMadud { get; set; }
        public string? Ragil { get; set; }
        public string? Gallery { get; set; }
        public string? Mirpeset { get; set; }
        public string? NewMirpeset { get; set; }
        public string? Martef { get; set; }
        public string? NewMartef { get; set; }
        public string? MirpesetMekura { get; set; }
        public string? NewMirpesetMekura { get; set; }
        public string? Energy { get; set; }
        public string? Pergula { get; set; }
        public string? NewPergula { get; set; }
        public string? EnergyPrivate { get; set; }
        public string? Gag { get; set; }
        public string? NewGag { get; set; }
        public string? KirotPenimi { get; set; }
        public string? KirotHitzoni { get; set; }
        public string? Kenyon { get; set; }
        public string? HatzerMavar { get; set; }
        public string? Pool { get; set; }
        public string? MirpesetGan { get; set; }
        public string? MachsanTzamud { get; set; }
        public string? MachsanNoTzamud { get; set; }
        public bool NoYaduaKeeyouma { get; set; }
        public bool AreaPitzul { get; set; }
        public bool MisparShimushim { get; set; }
        public string? TeurShimushim { get; set; }
        public bool IsNechesMeuhad { get; set; }
        public string? NechesMeuhad { get; set; }
        public bool IsNechesButal { get; set; }
        public string? NechesButal { get; set; }
        public string? NameNatzig { get; set; }
        public string? KesherNatzig { get; set; }
        public string? SignNatzig { get; set; }
        public string? NameModed { get; set; }
        public string? HourInModed { get; set; }
        public string? SignModed { get; set; }
        public string? Hearot { get; set; }
        public string? DateInModed { get; set; }
        public bool? IsEnergy { get; set; }
        public bool? IsEnergyPrivate { get; set; }
        public bool? IsGag { get; set; }
        public bool? IsGallery { get; set; }
        public bool? IsHatzerMavar { get; set; }
        public bool? IsKenyon { get; set; }
        public bool? IsKirotHitzoni { get; set; }
        public bool? IsKirotPenimi { get; set; }
        public bool? IsMachsanNoTzamud { get; set; }
        public bool? IsMachsanTzamud { get; set; }
        public bool? IsMartef { get; set; }
        public bool? IsMirpeset { get; set; }
        public bool? IsMirpesetGan { get; set; }
        public bool? IsMirpesetMekura { get; set; }
        public bool? IsNewGag { get; set; }
        public bool? IsNewMartef { get; set; }
        public bool? IsNewMirpeset { get; set; }
        public bool? IsNewMirpesetMekura { get; set; }
        public bool? IsNewPergula { get; set; }
        public bool? IsPergula { get; set; }
        public bool? IsPool { get; set; }
        public bool? IsRagil { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual AspNetUser? CreatedBy { get; set; }
        public virtual Property Property { get; set; } = null!;
        public virtual AspNetUser? UpdatedBy { get; set; }
    }
}
