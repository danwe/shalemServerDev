using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace shalemServer.Models
{
    public partial class ShalemDbDevContext : DbContext
    {
        public ShalemDbDevContext()
        {
        }

        public ShalemDbDevContext(DbContextOptions<ShalemDbDevContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; } = null!;
        public virtual DbSet<AreaCode> AreaCodes { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<AuditLog> AuditLogs { get; set; } = null!;
        public virtual DbSet<AuditProperty> AuditProperties { get; set; } = null!;
        public virtual DbSet<BuildingSoker> BuildingSokers { get; set; } = null!;
        public virtual DbSet<CategoryUse> CategoryUses { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Erf> Erves { get; set; } = null!;
        public virtual DbSet<Erp> Erps { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventType> EventTypes { get; set; } = null!;
        public virtual DbSet<File> Files { get; set; } = null!;
        public virtual DbSet<Filebackup> Filebackups { get; set; } = null!;
        public virtual DbSet<FloorSoker> FloorSokers { get; set; } = null!;
        public virtual DbSet<Job> Jobs { get; set; } = null!;
        public virtual DbSet<JobInfo> JobInfos { get; set; } = null!;
        public virtual DbSet<Mana> Manas { get; set; } = null!;
        public virtual DbSet<Property> Properties { get; set; } = null!;
        public virtual DbSet<PropertyOld> PropertyOlds { get; set; } = null!;
        public virtual DbSet<PropertySoker> PropertySokers { get; set; } = null!;
        public virtual DbSet<PropertyStatus> PropertyStatuses { get; set; } = null!;
        public virtual DbSet<PropertyType> PropertyTypes { get; set; } = null!;
        public virtual DbSet<PropertyUseType> PropertyUseTypes { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<RoleJob> RoleJobs { get; set; } = null!;
        public virtual DbSet<Str> Strs { get; set; } = null!;
        public virtual DbSet<Street> Streets { get; set; } = null!;
        public virtual DbSet<T> Ts { get; set; } = null!;
        public virtual DbSet<Table1> Table1s { get; set; } = null!;
        public virtual DbSet<Ttnoam> Ttnoams { get; set; } = null!;
        public virtual DbSet<Tx> Txes { get; set; } = null!;
        public virtual DbSet<UserJob> UserJobs { get; set; } = null!;
        public virtual DbSet<VUpdatedAreasByMunicipilty> VUpdatedAreasByMunicipilties { get; set; } = null!;
        public virtual DbSet<View2> View2s { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=ShalemDbDev;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Latin1_General_CI_AS");

            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.HasIndex(e => e.CreatedById, "IX_Area_CreatedByID");

                entity.HasIndex(e => e.PropertyId, "IX_Area_PropertyID");

                entity.HasIndex(e => e.UpdatedById, "IX_Area_UpdatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChargeArea).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.MeasureArea).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AreaCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Areas)
                    .HasForeignKey(d => d.PropertyId);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.AreaUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);
            });

            modelBuilder.Entity<AreaCode>(entity =>
            {
                entity.ToTable("AreaCode");

                entity.HasIndex(e => e.CreatedById, "IX_AreaCode_CreatedByID");

                entity.HasIndex(e => e.UpdatedById, "IX_AreaCode_UpdatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AreaCodeCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.AreaCodeUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.CreatedById, "IX_AspNetUsers_CreatedByID");

                entity.HasIndex(e => e.UpdatedById, "IX_AspNetUsers_UpdatedByID");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.DateCreated).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.DateUpdated).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.InverseCreatedBy)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.InverseUpdatedBy)
                    .HasForeignKey(d => d.UpdatedById);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AuditLog>(entity =>
            {
                entity.ToTable("AuditLog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateChanged).HasDefaultValueSql("('0001-01-01T00:00:00.0000000')");

                entity.Property(e => e.Pkid).HasColumnName("PKID");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<AuditProperty>(entity =>
            {
                entity.ToTable("AuditProperty");

                entity.HasIndex(e => e.CreatedById, "IX_AuditProperty_CreatedByID");

                entity.HasIndex(e => e.PropertyId, "IX_AuditProperty_PropertyID");

                entity.HasIndex(e => e.PropertyStatusId, "IX_AuditProperty_PropertyStatusID");

                entity.HasIndex(e => e.UpdatedById, "IX_AuditProperty_UpdatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.PropertyStatusId).HasColumnName("PropertyStatusID");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.AuditPropertyCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.AuditProperties)
                    .HasForeignKey(d => d.PropertyId);

                entity.HasOne(d => d.PropertyStatus)
                    .WithMany(p => p.AuditProperties)
                    .HasForeignKey(d => d.PropertyStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.AuditPropertyUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);
            });

            modelBuilder.Entity<BuildingSoker>(entity =>
            {
                entity.ToTable("BuildingSoker");

                entity.HasIndex(e => e.CreatedById, "IX_BuildingSoker_CreatedByID");

                entity.HasIndex(e => e.PropertyId, "IX_BuildingSoker_PropertyID")
                    .IsUnique();

                entity.HasIndex(e => e.UpdatedById, "IX_BuildingSoker_UpdatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.IsAreaShirut)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsGim)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsGisha)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsLobby)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMaalit1)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMaalit2)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMaderegotOut)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMaderegotnIn)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMiklat)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMtbahon)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsPool)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsShirutim)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.BuildingSokerCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Property)
                    .WithOne(p => p.BuildingSoker)
                    .HasForeignKey<BuildingSoker>(d => d.PropertyId);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.BuildingSokerUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);
            });

            modelBuilder.Entity<CategoryUse>(entity =>
            {
                entity.ToTable("CategoryUse");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Erf>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("erf");

                entity.Property(e => e.טבלה).HasMaxLength(255);

                entity.Property(e => e.סמלישוב).HasColumnName("סמל_ישוב");

                entity.Property(e => e.סמלרחוב).HasColumnName("סמל_רחוב");

                entity.Property(e => e.שםישוב)
                    .HasMaxLength(255)
                    .HasColumnName("שם_ישוב");

                entity.Property(e => e.שםרחוב)
                    .HasMaxLength(255)
                    .HasColumnName("שם_רחוב");
            });

            modelBuilder.Entity<Erp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("erp");

                entity.Property(e => e.טבלה).HasMaxLength(255);

                entity.Property(e => e.סמלישוב).HasColumnName("סמל_ישוב");

                entity.Property(e => e.סמלרחוב).HasColumnName("סמל_רחוב");

                entity.Property(e => e.שםישוב)
                    .HasMaxLength(255)
                    .HasColumnName("שם_ישוב");

                entity.Property(e => e.שםרחוב)
                    .HasMaxLength(255)
                    .HasColumnName("שם_רחוב");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.HasIndex(e => e.CreatedById, "IX_Event_CreatedByID");

                entity.HasIndex(e => e.EventTypeId, "IX_Event_EventTypeID");

                entity.HasIndex(e => e.HokerId, "IX_Event_HokerID");

                entity.HasIndex(e => e.PropertyId, "IX_Event_PropertyID");

                entity.HasIndex(e => e.UpdatedById, "IX_Event_UpdatedByID");

                entity.HasIndex(e => e.UserEventId, "IX_Event_UserEventID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.HokerId).HasColumnName("HokerID");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.Property(e => e.UserEventId).HasColumnName("UserEventID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.EventCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventTypeId);

                entity.HasOne(d => d.Hoker)
                    .WithMany(p => p.EventHokers)
                    .HasForeignKey(d => d.HokerId);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.PropertyId);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.EventUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);

                entity.HasOne(d => d.UserEvent)
                    .WithMany(p => p.EventUserEvents)
                    .HasForeignKey(d => d.UserEventId);
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventType");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("File");

                entity.HasIndex(e => e.CreatedById, "IX_File_CreatedByID");

                entity.HasIndex(e => e.PropertyId, "IX_File_PropertyID");

                entity.HasIndex(e => e.UpdatedById, "IX_File_UpdatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.FileCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.PropertyId);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.FileUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);
            });

            modelBuilder.Entity<Filebackup>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Filebackup");

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(450)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(450)
                    .HasColumnName("UpdatedByID");
            });

            modelBuilder.Entity<FloorSoker>(entity =>
            {
                entity.ToTable("FloorSoker");

                entity.HasIndex(e => e.CreatedById, "IX_FloorSoker_CreatedByID");

                entity.HasIndex(e => e.PropertyId, "IX_FloorSoker_PropertyID")
                    .IsUnique();

                entity.HasIndex(e => e.UpdatedById, "IX_FloorSoker_UpdatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.FloorSokerCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Property)
                    .WithOne(p => p.FloorSoker)
                    .HasForeignKey<FloorSoker>(d => d.PropertyId);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.FloorSokerUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<JobInfo>(entity =>
            {
                entity.ToTable("JobInfo");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Department).HasColumnName("department");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.UserName).HasColumnName("userName");
            });

            modelBuilder.Entity<Mana>(entity =>
            {
                entity.ToTable("Mana");

                entity.HasIndex(e => e.CreatedById, "IX_Mana_CreatedByID");

                entity.HasIndex(e => e.DepartmentId, "IX_Mana_DepartmentID");

                entity.HasIndex(e => e.UpdatedById, "IX_Mana_UpdatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.ManaCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Manas)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.ManaUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);
            });

            modelBuilder.Entity<Property>(entity =>
            {
                entity.ToTable("Property");

                entity.HasIndex(e => e.CreatedById, "IX_Property_CreatedByID");

                entity.HasIndex(e => e.DepartmentId, "IX_Property_DepartmentID");

                entity.HasIndex(e => e.ManaId, "IX_Property_ManaID");

                entity.HasIndex(e => e.ModedId, "IX_Property_ModedID");

                entity.HasIndex(e => e.PropertyStatusId, "IX_Property_PropertyStatusID");

                entity.HasIndex(e => e.PropertyTypeId, "IX_Property_PropertyTypeID");

                entity.HasIndex(e => e.SartatId, "IX_Property_SartatID");

                entity.HasIndex(e => e.UpdatedById, "IX_Property_UpdatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMedida)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.ManaId).HasColumnName("ManaID");

                entity.Property(e => e.ModedId).HasColumnName("ModedID");

                entity.Property(e => e.OldChargeArea).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.OldMeasureArea).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PropertyStatusId).HasColumnName("PropertyStatusID");

                entity.Property(e => e.PropertyTypeId).HasColumnName("PropertyTypeID");

                entity.Property(e => e.SartatId).HasColumnName("SartatID");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.PropertyCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.DepartmentId);

                entity.HasOne(d => d.Mana)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.ManaId);

                entity.HasOne(d => d.Moded)
                    .WithMany(p => p.PropertyModeds)
                    .HasForeignKey(d => d.ModedId);

                entity.HasOne(d => d.PropertyStatus)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.PropertyStatusId);

                entity.HasOne(d => d.PropertyType)
                    .WithMany(p => p.Properties)
                    .HasForeignKey(d => d.PropertyTypeId);

                entity.HasOne(d => d.Sartat)
                    .WithMany(p => p.PropertySartats)
                    .HasForeignKey(d => d.SartatId);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.PropertyUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);
            });

            modelBuilder.Entity<PropertyOld>(entity =>
            {
                entity.ToTable("PropertyOld");

                entity.HasIndex(e => e.ManaId, "IX_PropertyOld_ManaID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ManaId).HasColumnName("ManaID");

                entity.Property(e => e.SiteId).HasColumnName("SiteID");

                entity.HasOne(d => d.Mana)
                    .WithMany(p => p.PropertyOlds)
                    .HasForeignKey(d => d.ManaId);
            });

            modelBuilder.Entity<PropertySoker>(entity =>
            {
                entity.ToTable("PropertySoker");

                entity.HasIndex(e => e.CreatedById, "IX_PropertySoker_CreatedByID");

                entity.HasIndex(e => e.PropertyId, "IX_PropertySoker_PropertyID")
                    .IsUnique();

                entity.HasIndex(e => e.UpdatedById, "IX_PropertySoker_UpdatedByID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedById).HasColumnName("CreatedByID");

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsEnergy)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsEnergyPrivate)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsGag)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsGallery)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsHatzerMavar)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsKenyon)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsKirotHitzoni)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsKirotPenimi)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMachsanNoTzamud)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMachsanTzamud)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMartef)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMirpeset)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMirpesetGan)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsMirpesetMekura)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsNewGag)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsNewMartef)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsNewMirpeset)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsNewMirpesetMekura)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsNewPergula)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsPergula)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsPool)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.IsRagil)
                    .IsRequired()
                    .HasDefaultValueSql("(CONVERT([bit],(0)))");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UpdatedById).HasColumnName("UpdatedByID");

                entity.HasOne(d => d.CreatedBy)
                    .WithMany(p => p.PropertySokerCreatedBies)
                    .HasForeignKey(d => d.CreatedById);

                entity.HasOne(d => d.Property)
                    .WithOne(p => p.PropertySoker)
                    .HasForeignKey<PropertySoker>(d => d.PropertyId);

                entity.HasOne(d => d.UpdatedBy)
                    .WithMany(p => p.PropertySokerUpdatedBies)
                    .HasForeignKey(d => d.UpdatedById);
            });

            modelBuilder.Entity<PropertyStatus>(entity =>
            {
                entity.ToTable("PropertyStatus");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<PropertyType>(entity =>
            {
                entity.ToTable("PropertyType");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<PropertyUseType>(entity =>
            {
                entity.ToTable("PropertyUseType");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<RoleJob>(entity =>
            {
                entity.ToTable("RoleJob");

                entity.HasIndex(e => e.JobId, "IX_RoleJob_JobID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.RoleJobs)
                    .HasForeignKey(d => d.JobId);
            });

            modelBuilder.Entity<Str>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("str");

                entity.Property(e => e.F3).HasMaxLength(255);

                entity.Property(e => e.F5).HasMaxLength(255);

                entity.Property(e => e._20200701231950).HasColumnName("2020-07-01 23:19:50");

                entity.Property(e => e.נכוןלתאריך)
                    .HasMaxLength(255)
                    .HasColumnName("נכון_לתאריך");
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.ToTable("Street");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<T>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("t");

                entity.Property(e => e.Sitem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sitem");

                entity.Property(e => e.Sitemx)
                    .HasMaxLength(10)
                    .HasColumnName("sitemx")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Table1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Table_1");

                entity.Property(e => e.Bnm).HasColumnName("bnm");
            });

            modelBuilder.Entity<Ttnoam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ttnoam");

                entity.Property(e => e.ContentType)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");
            });

            modelBuilder.Entity<Tx>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tx");

                entity.Property(e => e.Sitem)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sitem");

                entity.Property(e => e.Sitemx)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("sitemx");
            });

            modelBuilder.Entity<UserJob>(entity =>
            {
                entity.ToTable("UserJob");

                entity.HasIndex(e => e.ApplicationUserId, "IX_UserJob_ApplicationUserID");

                entity.HasIndex(e => e.JobId, "IX_UserJob_JobID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ApplicationUserId).HasColumnName("ApplicationUserID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.UserJobs)
                    .HasForeignKey(d => d.ApplicationUserId);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.UserJobs)
                    .HasForeignKey(d => d.JobId);
            });

            modelBuilder.Entity<VUpdatedAreasByMunicipilty>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("V_updatedAreasByMunicipilty");

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            });

            modelBuilder.Entity<View2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_2");

                entity.Property(e => e.ContentType)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("CreatedByID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyId).HasColumnName("PropertyID");

                entity.Property(e => e.UpdatedById)
                    .HasMaxLength(36)
                    .IsUnicode(false)
                    .HasColumnName("UpdatedByID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
