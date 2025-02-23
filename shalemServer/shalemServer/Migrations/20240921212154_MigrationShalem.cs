using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shalemServer.Migrations
{
    public partial class MigrationShalem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('0001-01-01T00:00:00.0000000')"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('0001-01-01T00:00:00.0000000')"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AspNetUsers_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateChanged = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "('0001-01-01T00:00:00.0000000')"),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PKID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryUse",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryUse", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "erf",
                columns: table => new
                {
                    טבלה = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    סמל_ישוב = table.Column<double>(type: "float", nullable: true),
                    שם_ישוב = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    סמל_רחוב = table.Column<double>(type: "float", nullable: true),
                    שם_רחוב = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "erp",
                columns: table => new
                {
                    טבלה = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    סמל_ישוב = table.Column<double>(type: "float", nullable: true),
                    שם_ישוב = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    סמל_רחוב = table.Column<double>(type: "float", nullable: true),
                    שם_רחוב = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "EventType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Filebackup",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Job", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "JobInfo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    comment = table.Column<int>(type: "int", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyStatus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PropertyUseType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyUseType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "str",
                columns: table => new
                {
                    נכון_לתאריך = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    _20200701231950 = table.Column<double>(name: "2020-07-01 23:19:50", type: "float", nullable: true),
                    F3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    F4 = table.Column<double>(type: "float", nullable: true),
                    F5 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Street",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Street", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "t",
                columns: table => new
                {
                    sitem = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    sitemx = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Table_1",
                columns: table => new
                {
                    bnm = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "ttnoam",
                columns: table => new
                {
                    UpdatedByID = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    CreatedByID = table.Column<string>(type: "varchar(36)", unicode: false, maxLength: 36, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateUpdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FullName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ContentType = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "tx",
                columns: table => new
                {
                    sitem = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    sitemx = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreaCode",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCharge = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaCode", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AreaCode_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AreaCode_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mana",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManaNumber = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    PropCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mana", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Mana_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mana_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mana_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RoleJob",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleJob", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleJob_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJob",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJob", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserJob_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJob_Job_JobID",
                        column: x => x.JobID,
                        principalTable: "Job",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    PropertyTypeID = table.Column<int>(type: "int", nullable: false),
                    ModedID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SartatID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PropertyStatusID = table.Column<int>(type: "int", nullable: false),
                    BuildingSite = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertySite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<int>(type: "int", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingYear = table.Column<int>(type: "int", nullable: true),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldChargeArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OldMeasureArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMedida = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    Mivnan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasureEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MeasureStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ManaID = table.Column<int>(type: "int", nullable: true),
                    MedidaComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyDetailes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    NameOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Property_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Property_AspNetUsers_ModedID",
                        column: x => x.ModedID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Property_AspNetUsers_SartatID",
                        column: x => x.SartatID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Property_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Property_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_Mana_ManaID",
                        column: x => x.ManaID,
                        principalTable: "Mana",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Property_PropertyStatus_PropertyStatusID",
                        column: x => x.PropertyStatusID,
                        principalTable: "PropertyStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Property_PropertyType_PropertyTypeID",
                        column: x => x.PropertyTypeID,
                        principalTable: "PropertyType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyOld",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SiteID = table.Column<int>(type: "int", nullable: false),
                    ManaID = table.Column<int>(type: "int", nullable: false),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManaName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyOld", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertyOld_Mana_ManaID",
                        column: x => x.ManaID,
                        principalTable: "Mana",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    ChargeArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MeasureArea = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContractNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstallationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    AreaCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropertyUseType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Area_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Area_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuditProperty",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    PropertyStatusID = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditProperty", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AuditProperty_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditProperty_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AuditProperty_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuditProperty_PropertyStatus_PropertyStatusID",
                        column: x => x.PropertyStatusID,
                        principalTable: "PropertyStatus",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BuildingSoker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    Mazmina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsPinatit = table.Column<bool>(type: "bit", nullable: false),
                    Pinatit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorOnKarka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorDownKaraka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsComany = table.Column<bool>(type: "bit", nullable: false),
                    Comany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mezahe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gisha = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maalit1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Maalit2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mtbahon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lobby = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaShirut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miklat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaderegotnIn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaderegotOut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shirutim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<bool>(type: "bit", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsAreaShirut = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsGim = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsGisha = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsLobby = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMaalit1 = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMaalit2 = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMaderegotOut = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMaderegotnIn = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMiklat = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMtbahon = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsPool = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsShirutim = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    DateInModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourInModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesherNatzig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameNatzig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignNatzig = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingSoker", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BuildingSoker_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuildingSoker_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BuildingSoker_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: true),
                    UserEventID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EventTypeID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HokerID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_HokerID",
                        column: x => x.HokerID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_AspNetUsers_UserEventID",
                        column: x => x.UserEventID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_EventType_EventTypeID",
                        column: x => x.EventTypeID,
                        principalTable: "EventType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Event_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.ID);
                    table.ForeignKey(
                        name: "FK_File_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_File_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FloorSoker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    Mazmina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNumberActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsTimroon = table.Column<bool>(type: "bit", nullable: false),
                    Timroon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMirpesetKoma = table.Column<bool>(type: "bit", nullable: false),
                    MirpesetKoma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMirpesetKoma1 = table.Column<bool>(type: "bit", nullable: false),
                    MirpesetKoma1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMisdaronKoma = table.Column<bool>(type: "bit", nullable: false),
                    Misdaron = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMisdaronKoma1 = table.Column<bool>(type: "bit", nullable: false),
                    MisdaronKoma1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsKitchen1 = table.Column<bool>(type: "bit", nullable: false),
                    Kitchen1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsKitchen2 = table.Column<bool>(type: "bit", nullable: false),
                    Kitchen2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsKitchen3 = table.Column<bool>(type: "bit", nullable: false),
                    Kitchen3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLobby1 = table.Column<bool>(type: "bit", nullable: false),
                    Lobby1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLobby2 = table.Column<bool>(type: "bit", nullable: false),
                    Lobby2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMamak1 = table.Column<bool>(type: "bit", nullable: false),
                    Mamak1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMamak2 = table.Column<bool>(type: "bit", nullable: false),
                    Mamak2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMaderegotOut = table.Column<bool>(type: "bit", nullable: false),
                    MaderegotOut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMaderegot = table.Column<bool>(type: "bit", nullable: false),
                    Maderegot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShirutim1 = table.Column<bool>(type: "bit", nullable: false),
                    Shirutim1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShirutim2 = table.Column<bool>(type: "bit", nullable: false),
                    Shirutim2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAreaShirut = table.Column<bool>(type: "bit", nullable: false),
                    AreaShirut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<bool>(type: "bit", nullable: false),
                    NameModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    DateInModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourInModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesherNatzig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameNatzig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignNatzig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorSoker", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FloorSoker_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FloorSoker_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FloorSoker_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertySoker",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedByID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PropertyID = table.Column<int>(type: "int", nullable: false),
                    Mazmina = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FloorNumberActive = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nimdad = table.Column<bool>(type: "bit", nullable: false),
                    Sarvan = table.Column<bool>(type: "bit", nullable: false),
                    Sagur = table.Column<bool>(type: "bit", nullable: false),
                    Neheras = table.Column<bool>(type: "bit", nullable: false),
                    Pail = table.Column<bool>(type: "bit", nullable: false),
                    NoPail = table.Column<bool>(type: "bit", nullable: false),
                    Empty = table.Column<bool>(type: "bit", nullable: false),
                    NoRaouy = table.Column<bool>(type: "bit", nullable: false),
                    Shiputs = table.Column<bool>(type: "bit", nullable: false),
                    Harisa = table.Column<bool>(type: "bit", nullable: false),
                    BuissnesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuissnesNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dira = table.Column<bool>(type: "bit", nullable: false),
                    Misrad = table.Column<bool>(type: "bit", nullable: false),
                    Mchsan = table.Column<bool>(type: "bit", nullable: false),
                    Hanut = table.Column<bool>(type: "bit", nullable: false),
                    Parking = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeShimush = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeurShimush = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShimushDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Images = table.Column<bool>(type: "bit", nullable: false),
                    MchzikName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoYadua = table.Column<bool>(type: "bit", nullable: false),
                    IsOwner = table.Column<bool>(type: "bit", nullable: false),
                    IsTenant = table.Column<bool>(type: "bit", nullable: false),
                    IsPolesh = table.Column<bool>(type: "bit", nullable: false),
                    IsKey = table.Column<bool>(type: "bit", nullable: false),
                    Isbk = table.Column<bool>(type: "bit", nullable: false),
                    ActiveMchzikName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MisparMezahe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateHahezaka = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaHiuv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaMadud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ragil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gallery = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mirpeset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewMirpeset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Martef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewMartef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MirpesetMekura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewMirpesetMekura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Energy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pergula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewPergula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnergyPrivate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewGag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KirotPenimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KirotHitzoni = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kenyon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HatzerMavar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pool = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MirpesetGan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachsanTzamud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MachsanNoTzamud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoYaduaKeeyouma = table.Column<bool>(type: "bit", nullable: false),
                    AreaPitzul = table.Column<bool>(type: "bit", nullable: false),
                    MisparShimushim = table.Column<bool>(type: "bit", nullable: false),
                    TeurShimushim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNechesMeuhad = table.Column<bool>(type: "bit", nullable: false),
                    NechesMeuhad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNechesButal = table.Column<bool>(type: "bit", nullable: false),
                    NechesButal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameNatzig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KesherNatzig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignNatzig = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HourInModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SignModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hearot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateInModed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsEnergy = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsEnergyPrivate = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsGag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsGallery = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsHatzerMavar = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsKenyon = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsKirotHitzoni = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsKirotPenimi = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMachsanNoTzamud = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMachsanTzamud = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMartef = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMirpeset = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMirpesetGan = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsMirpesetMekura = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsNewGag = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsNewMartef = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsNewMirpeset = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsNewMirpesetMekura = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsNewPergula = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsPergula = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsPool = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsRagil = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "(CONVERT([bit],(0)))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySoker", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PropertySoker_AspNetUsers_CreatedByID",
                        column: x => x.CreatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertySoker_AspNetUsers_UpdatedByID",
                        column: x => x.UpdatedByID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PropertySoker_Property_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Property",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_CreatedByID",
                table: "Area",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_PropertyID",
                table: "Area",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Area_UpdatedByID",
                table: "Area",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AreaCode_CreatedByID",
                table: "AreaCode",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AreaCode_UpdatedByID",
                table: "AreaCode",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "([NormalizedName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_CreatedByID",
                table: "AspNetUsers",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UpdatedByID",
                table: "AspNetUsers",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "([NormalizedUserName] IS NOT NULL)");

            migrationBuilder.CreateIndex(
                name: "IX_AuditProperty_CreatedByID",
                table: "AuditProperty",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditProperty_PropertyID",
                table: "AuditProperty",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditProperty_PropertyStatusID",
                table: "AuditProperty",
                column: "PropertyStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_AuditProperty_UpdatedByID",
                table: "AuditProperty",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingSoker_CreatedByID",
                table: "BuildingSoker",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_BuildingSoker_PropertyID",
                table: "BuildingSoker",
                column: "PropertyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BuildingSoker_UpdatedByID",
                table: "BuildingSoker",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_CreatedByID",
                table: "Event",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventTypeID",
                table: "Event",
                column: "EventTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_HokerID",
                table: "Event",
                column: "HokerID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_PropertyID",
                table: "Event",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_UpdatedByID",
                table: "Event",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Event_UserEventID",
                table: "Event",
                column: "UserEventID");

            migrationBuilder.CreateIndex(
                name: "IX_File_CreatedByID",
                table: "File",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_File_PropertyID",
                table: "File",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_File_UpdatedByID",
                table: "File",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FloorSoker_CreatedByID",
                table: "FloorSoker",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_FloorSoker_PropertyID",
                table: "FloorSoker",
                column: "PropertyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FloorSoker_UpdatedByID",
                table: "FloorSoker",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Mana_CreatedByID",
                table: "Mana",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Mana_DepartmentID",
                table: "Mana",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Mana_UpdatedByID",
                table: "Mana",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_CreatedByID",
                table: "Property",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_DepartmentID",
                table: "Property",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_ManaID",
                table: "Property",
                column: "ManaID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_ModedID",
                table: "Property",
                column: "ModedID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PropertyStatusID",
                table: "Property",
                column: "PropertyStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_PropertyTypeID",
                table: "Property",
                column: "PropertyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_SartatID",
                table: "Property",
                column: "SartatID");

            migrationBuilder.CreateIndex(
                name: "IX_Property_UpdatedByID",
                table: "Property",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyOld_ManaID",
                table: "PropertyOld",
                column: "ManaID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySoker_CreatedByID",
                table: "PropertySoker",
                column: "CreatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertySoker_PropertyID",
                table: "PropertySoker",
                column: "PropertyID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PropertySoker_UpdatedByID",
                table: "PropertySoker",
                column: "UpdatedByID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleJob_JobID",
                table: "RoleJob",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_UserJob_ApplicationUserID",
                table: "UserJob",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserJob_JobID",
                table: "UserJob",
                column: "JobID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "AreaCode");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "AuditProperty");

            migrationBuilder.DropTable(
                name: "BuildingSoker");

            migrationBuilder.DropTable(
                name: "CategoryUse");

            migrationBuilder.DropTable(
                name: "erf");

            migrationBuilder.DropTable(
                name: "erp");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Filebackup");

            migrationBuilder.DropTable(
                name: "FloorSoker");

            migrationBuilder.DropTable(
                name: "JobInfo");

            migrationBuilder.DropTable(
                name: "PropertyOld");

            migrationBuilder.DropTable(
                name: "PropertySoker");

            migrationBuilder.DropTable(
                name: "PropertyUseType");

            migrationBuilder.DropTable(
                name: "Report");

            migrationBuilder.DropTable(
                name: "RoleJob");

            migrationBuilder.DropTable(
                name: "str");

            migrationBuilder.DropTable(
                name: "Street");

            migrationBuilder.DropTable(
                name: "t");

            migrationBuilder.DropTable(
                name: "Table_1");

            migrationBuilder.DropTable(
                name: "ttnoam");

            migrationBuilder.DropTable(
                name: "tx");

            migrationBuilder.DropTable(
                name: "UserJob");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "EventType");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Mana");

            migrationBuilder.DropTable(
                name: "PropertyStatus");

            migrationBuilder.DropTable(
                name: "PropertyType");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
