using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trips.Migrations
{
    public partial class InitialModelCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "dbo",
                columns: table => new
                {
                    ShortName = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ShortName);
                });

            migrationBuilder.CreateTable(
                name: "Institutes",
                schema: "dbo",
                columns: table => new
                {
                    InstituteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 128, nullable: false),
                    ShortName = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institutes", x => x.InstituteId);
                });

            migrationBuilder.CreateTable(
                name: "State",
                schema: "dbo",
                columns: table => new
                {
                    ShortName = table.Column<string>(maxLength: 10, nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.ShortName);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    NEDId = table.Column<string>(maxLength: 25, nullable: false),
                    AppointmentType = table.Column<string>(maxLength: 255, nullable: true),
                    BranchShortName = table.Column<string>(maxLength: 25, nullable: true),
                    DivisionShortName = table.Column<string>(maxLength: 25, nullable: true),
                    EMail = table.Column<string>(maxLength: 255, nullable: true),
                    FirstName = table.Column<string>(maxLength: 128, nullable: true),
                    FullName = table.Column<string>(maxLength: 255, nullable: true),
                    FullNameLegal = table.Column<string>(maxLength: 255, nullable: true),
                    InstituteShortName = table.Column<string>(maxLength: 25, nullable: true),
                    JobTitle = table.Column<string>(maxLength: 255, nullable: true),
                    LastName = table.Column<string>(maxLength: 128, nullable: true),
                    LoginId = table.Column<string>(maxLength: 25, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 128, nullable: true),
                    NIHSAC = table.Column<string>(maxLength: 25, nullable: true),
                    NIH_ORG_PATH = table.Column<string>(maxLength: 255, nullable: true),
                    PositionTitle = table.Column<string>(maxLength: 255, nullable: true),
                    SignatureName = table.Column<string>(maxLength: 255, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    SupervisorNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    SupervisorName = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.NEDId);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                schema: "dbo",
                columns: table => new
                {
                    DivisionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    DefaultLodgeOffset = table.Column<int>(nullable: false),
                    DefaultMealFirstPercent = table.Column<int>(nullable: false),
                    DefaultMealLastPercent = table.Column<int>(nullable: false),
                    DefaultOtherRate = table.Column<int>(nullable: false),
                    DefaultTravelStartOffset = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false),
                    FiscalYearLock = table.Column<int>(nullable: false),
                    InstituteId = table.Column<int>(nullable: false),
                    IsLocked = table.Column<bool>(nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    NIHSAC = table.Column<string>(nullable: true),
                    ShortName = table.Column<string>(maxLength: 25, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionId);
                    table.ForeignKey(
                        name: "FK_Divisions_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Divisions_Institutes_InstituteId",
                        column: x => x.InstituteId,
                        principalSchema: "dbo",
                        principalTable: "Institutes",
                        principalColumn: "InstituteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Divisions_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Divisions_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Miscellaneous",
                schema: "dbo",
                columns: table => new
                {
                    MiscellaneousId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    Key = table.Column<string>(maxLength: 128, nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    Module = table.Column<string>(maxLength: 128, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false),
                    Value = table.Column<string>(maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Miscellaneous", x => x.MiscellaneousId);
                    table.ForeignKey(
                        name: "FK_Miscellaneous_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Miscellaneous_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Miscellaneous_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                schema: "dbo",
                columns: table => new
                {
                    PriorityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false),
                    IncludeInSummary = table.Column<bool>(nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.PriorityId);
                    table.ForeignKey(
                        name: "FK_Priority_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Priority_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Priority_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "dbo",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false),
                    BranchLevel = table.Column<bool>(nullable: false),
                    CanManageSelf = table.Column<bool>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false),
                    DivisionLevel = table.Column<bool>(nullable: false),
                    InstituteLevel = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    ParentRoleId = table.Column<int>(nullable: true),
                    ShortName = table.Column<string>(maxLength: 25, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Roles_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_Roles_ParentRoleId",
                        column: x => x.ParentRoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Roles_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TravelType",
                schema: "dbo",
                columns: table => new
                {
                    TravelTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelType", x => x.TravelTypeId);
                    table.ForeignKey(
                        name: "FK_TravelType_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelType_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TravelType_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Branches",
                schema: "dbo",
                columns: table => new
                {
                    BranchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveUntil = table.Column<DateTime>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    NIHSAC = table.Column<string>(maxLength: 255, nullable: true),
                    ShortName = table.Column<string>(maxLength: 25, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                    table.ForeignKey(
                        name: "FK_Branches_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "dbo",
                        principalTable: "Divisions",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Branches_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cans",
                schema: "dbo",
                columns: table => new
                {
                    CanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActiveUntil = table.Column<DateTime>(nullable: true),
                    CanNumber = table.Column<string>(maxLength: 25, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    Description = table.Column<string>(maxLength: 128, nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    ProjectNumber = table.Column<string>(maxLength: 128, nullable: true),
                    Reimbursable = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cans", x => x.CanId);
                    table.ForeignKey(
                        name: "FK_Cans_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cans_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "dbo",
                        principalTable: "Divisions",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cans_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cans_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvitationalTravelers",
                schema: "dbo",
                columns: table => new
                {
                    InvitationalTravelerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContactEmail = table.Column<string>(maxLength: 255, nullable: true),
                    ContactPhone = table.Column<string>(maxLength: 30, nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    LastName = table.Column<string>(maxLength: 255, nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    MiddleName = table.Column<string>(maxLength: 255, nullable: true),
                    OrganizationName = table.Column<string>(maxLength: 255, nullable: true),
                    OrganizationPhone = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvitationalTravelers", x => x.InvitationalTravelerId);
                    table.ForeignKey(
                        name: "FK_InvitationalTravelers_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvitationalTravelers_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "dbo",
                        principalTable: "Divisions",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvitationalTravelers_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvitationalTravelers_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    NEDId = table.Column<string>(maxLength: 25, nullable: false),
                    OrganizationId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_NEDId",
                        column: x => x.NEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CanAllocations",
                columns: table => new
                {
                    CanAllocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BranchId = table.Column<int>(nullable: false),
                    CanId = table.Column<int>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    DivisionId = table.Column<int>(nullable: false),
                    FiscalYear = table.Column<int>(nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    POTSAmount = table.Column<decimal>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false),
                    TravelAmount = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanAllocations", x => x.CanAllocationId);
                    table.ForeignKey(
                        name: "FK_CanAllocations_Branches_BranchId",
                        column: x => x.BranchId,
                        principalSchema: "dbo",
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CanAllocations_Cans_CanId",
                        column: x => x.CanId,
                        principalSchema: "dbo",
                        principalTable: "Cans",
                        principalColumn: "CanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CanAllocations_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CanAllocations_Divisions_DivisionId",
                        column: x => x.DivisionId,
                        principalSchema: "dbo",
                        principalTable: "Divisions",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CanAllocations_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CanAllocations_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CanSubAllocations",
                schema: "dbo",
                columns: table => new
                {
                    CanSubAllocationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CanAllocationId = table.Column<int>(nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    CreateUserNEDId = table.Column<string>(maxLength: 25, nullable: false),
                    LastUpdateDateTime = table.Column<DateTime>(nullable: true),
                    LastUpdateUserNEDId = table.Column<string>(maxLength: 25, nullable: true),
                    NEDId = table.Column<string>(maxLength: 25, nullable: false),
                    POTSAmount = table.Column<decimal>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StatusUpdateDateTime = table.Column<DateTime>(nullable: false),
                    StatusUpdateUserNEDId = table.Column<string>(nullable: false),
                    TravelAmount = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CanSubAllocations", x => x.CanSubAllocationId);
                    table.ForeignKey(
                        name: "FK_CanSubAllocations_CanAllocations_CanAllocationId",
                        column: x => x.CanAllocationId,
                        principalTable: "CanAllocations",
                        principalColumn: "CanAllocationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CanSubAllocations_Users_CreateUserNEDId",
                        column: x => x.CreateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CanSubAllocations_Users_LastUpdateUserNEDId",
                        column: x => x.LastUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CanSubAllocations_Users_NEDId",
                        column: x => x.NEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CanSubAllocations_Users_StatusUpdateUserNEDId",
                        column: x => x.StatusUpdateUserNEDId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "NEDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CanAllocations_BranchId",
                table: "CanAllocations",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CanAllocations_CanId",
                table: "CanAllocations",
                column: "CanId");

            migrationBuilder.CreateIndex(
                name: "IX_CanAllocations_CreateUserNEDId",
                table: "CanAllocations",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_CanAllocations_DivisionId",
                table: "CanAllocations",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_CanAllocations_LastUpdateUserNEDId",
                table: "CanAllocations",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_CanAllocations_StatusUpdateUserNEDId",
                table: "CanAllocations",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_CreateUserNEDId",
                schema: "dbo",
                table: "Branches",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_DivisionId",
                schema: "dbo",
                table: "Branches",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Branches",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Branches",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Cans_CreateUserNEDId",
                schema: "dbo",
                table: "Cans",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Cans_DivisionId",
                schema: "dbo",
                table: "Cans",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_Cans_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Cans",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Cans_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Cans",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_CanSubAllocations_CanAllocationId",
                schema: "dbo",
                table: "CanSubAllocations",
                column: "CanAllocationId");

            migrationBuilder.CreateIndex(
                name: "IX_CanSubAllocations_CreateUserNEDId",
                schema: "dbo",
                table: "CanSubAllocations",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_CanSubAllocations_LastUpdateUserNEDId",
                schema: "dbo",
                table: "CanSubAllocations",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_CanSubAllocations_NEDId",
                schema: "dbo",
                table: "CanSubAllocations",
                column: "NEDId");

            migrationBuilder.CreateIndex(
                name: "IX_CanSubAllocations_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "CanSubAllocations",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_CreateUserNEDId",
                schema: "dbo",
                table: "Divisions",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_InstituteId",
                schema: "dbo",
                table: "Divisions",
                column: "InstituteId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Divisions",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Divisions",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationalTravelers_CreateUserNEDId",
                schema: "dbo",
                table: "InvitationalTravelers",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationalTravelers_DivisionId",
                schema: "dbo",
                table: "InvitationalTravelers",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationalTravelers_LastUpdateUserNEDId",
                schema: "dbo",
                table: "InvitationalTravelers",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_InvitationalTravelers_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "InvitationalTravelers",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Miscellaneous_CreateUserNEDId",
                schema: "dbo",
                table: "Miscellaneous",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Miscellaneous_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Miscellaneous",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Miscellaneous_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Miscellaneous",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Priority_CreateUserNEDId",
                schema: "dbo",
                table: "Priority",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Priority_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Priority",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Priority_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Priority",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreateUserNEDId",
                schema: "dbo",
                table: "Roles",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Roles",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ParentRoleId",
                schema: "dbo",
                table: "Roles",
                column: "ParentRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Roles",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelType_CreateUserNEDId",
                schema: "dbo",
                table: "TravelType",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelType_LastUpdateUserNEDId",
                schema: "dbo",
                table: "TravelType",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_TravelType_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "TravelType",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_CreateUserNEDId",
                schema: "dbo",
                table: "UserRoles",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_LastUpdateUserNEDId",
                schema: "dbo",
                table: "UserRoles",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_NEDId",
                schema: "dbo",
                table: "UserRoles",
                column: "NEDId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "dbo",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "UserRoles",
                column: "StatusUpdateUserNEDId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CanSubAllocations",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InvitationalTravelers",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Miscellaneous",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Priority",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "State",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TravelType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CanAllocations");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Branches",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Cans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Divisions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Institutes",
                schema: "dbo");
        }
    }
}
