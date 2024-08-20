using System;
using System.Collections.Generic;

namespace shalemServer.Models
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            AreaCodeCreatedBies = new HashSet<AreaCode>();
            AreaCodeUpdatedBies = new HashSet<AreaCode>();
            AreaCreatedBies = new HashSet<Area>();
            AreaUpdatedBies = new HashSet<Area>();
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            AuditPropertyCreatedBies = new HashSet<AuditProperty>();
            AuditPropertyUpdatedBies = new HashSet<AuditProperty>();
            BuildingSokerCreatedBies = new HashSet<BuildingSoker>();
            BuildingSokerUpdatedBies = new HashSet<BuildingSoker>();
            EventCreatedBies = new HashSet<Event>();
            EventHokers = new HashSet<Event>();
            EventUpdatedBies = new HashSet<Event>();
            EventUserEvents = new HashSet<Event>();
            FileCreatedBies = new HashSet<File>();
            FileUpdatedBies = new HashSet<File>();
            FloorSokerCreatedBies = new HashSet<FloorSoker>();
            FloorSokerUpdatedBies = new HashSet<FloorSoker>();
            InverseCreatedBy = new HashSet<AspNetUser>();
            InverseUpdatedBy = new HashSet<AspNetUser>();
            ManaCreatedBies = new HashSet<Mana>();
            ManaUpdatedBies = new HashSet<Mana>();
            PropertyCreatedBies = new HashSet<Property>();
            PropertyModeds = new HashSet<Property>();
            PropertySartats = new HashSet<Property>();
            PropertySokerCreatedBies = new HashSet<PropertySoker>();
            PropertySokerUpdatedBies = new HashSet<PropertySoker>();
            PropertyUpdatedBies = new HashSet<Property>();
            UserJobs = new HashSet<UserJob>();
            Roles = new HashSet<AspNetRole>();
        }

        public string Id { get; set; } = null!;
        public string? UserName { get; set; }
        public string? NormalizedUserName { get; set; }
        public string? Email { get; set; }
        public string? NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string? PasswordHash { get; set; }
        public string? SecurityStamp { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public string? PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string? CreatedById { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? UpdatedById { get; set; }
        public bool? IsActive { get; set; }

        public virtual AspNetUser? CreatedBy { get; set; }
        public virtual AspNetUser? UpdatedBy { get; set; }
        public virtual ICollection<AreaCode> AreaCodeCreatedBies { get; set; }
        public virtual ICollection<AreaCode> AreaCodeUpdatedBies { get; set; }
        public virtual ICollection<Area> AreaCreatedBies { get; set; }
        public virtual ICollection<Area> AreaUpdatedBies { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<AuditProperty> AuditPropertyCreatedBies { get; set; }
        public virtual ICollection<AuditProperty> AuditPropertyUpdatedBies { get; set; }
        public virtual ICollection<BuildingSoker> BuildingSokerCreatedBies { get; set; }
        public virtual ICollection<BuildingSoker> BuildingSokerUpdatedBies { get; set; }
        public virtual ICollection<Event> EventCreatedBies { get; set; }
        public virtual ICollection<Event> EventHokers { get; set; }
        public virtual ICollection<Event> EventUpdatedBies { get; set; }
        public virtual ICollection<Event> EventUserEvents { get; set; }
        public virtual ICollection<File> FileCreatedBies { get; set; }
        public virtual ICollection<File> FileUpdatedBies { get; set; }
        public virtual ICollection<FloorSoker> FloorSokerCreatedBies { get; set; }
        public virtual ICollection<FloorSoker> FloorSokerUpdatedBies { get; set; }
        public virtual ICollection<AspNetUser> InverseCreatedBy { get; set; }
        public virtual ICollection<AspNetUser> InverseUpdatedBy { get; set; }
        public virtual ICollection<Mana> ManaCreatedBies { get; set; }
        public virtual ICollection<Mana> ManaUpdatedBies { get; set; }
        public virtual ICollection<Property> PropertyCreatedBies { get; set; }
        public virtual ICollection<Property> PropertyModeds { get; set; }
        public virtual ICollection<Property> PropertySartats { get; set; }
        public virtual ICollection<PropertySoker> PropertySokerCreatedBies { get; set; }
        public virtual ICollection<PropertySoker> PropertySokerUpdatedBies { get; set; }
        public virtual ICollection<Property> PropertyUpdatedBies { get; set; }
        public virtual ICollection<UserJob> UserJobs { get; set; }

        public virtual ICollection<AspNetRole> Roles { get; set; }
    }
}
