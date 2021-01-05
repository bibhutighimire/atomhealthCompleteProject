using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class changes : Migration
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
                    BloodType = table.Column<string>(type: "varchar(100)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MedicalConditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastMedicalHistoryDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsInMedicaion = table.Column<string>(type: "varchar(20)", nullable: true),
                    Medications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasPastSurgery = table.Column<string>(type: "varchar(20)", nullable: true),
                    PastSurgeries = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasAllergy = table.Column<string>(type: "varchar(20)", nullable: true),
                    Allergies = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyHistory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hasGeneticTest = table.Column<string>(type: "varchar(20)", nullable: true),
                    GeneticTest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CovidDetails = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ImmunizationRecord = table.Column<string>(type: "nvarchar(1000)", nullable: true),
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
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "CovidHistory",
                columns: table => new
                {
                    CovidHistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CovidHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidHistory", x => x.CovidHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "CurrentMedicalCondition",
                columns: table => new
                {
                    CurrentMedicalConditionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentMedicalConditionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMedicalCondition", x => x.CurrentMedicalConditionID);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMedicalHistory",
                columns: table => new
                {
                    FamilyMedicalHistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FamilyMedicalHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMedicalHistory", x => x.FamilyMedicalHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "Immunization",
                columns: table => new
                {
                    ImmunizationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImmunizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Immunization", x => x.ImmunizationID);
                });

            migrationBuilder.CreateTable(
                name: "MedicalHistory",
                columns: table => new
                {
                    MedicalHistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalHistory", x => x.MedicalHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "PastMedicalHistory",
                columns: table => new
                {
                    PastMedicalHistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastMedicalHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastMedicalHistory", x => x.PastMedicalHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "Subscribe",
                columns: table => new
                {
                    subscribeid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribe", x => x.subscribeid);
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
                name: "ApplicationUser",
                columns: table => new
                {
                    ApplicationUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Gender = table.Column<string>(type: "varchar(50)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "varchar(100)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.ApplicationUserID);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Lifestyle",
                columns: table => new
                {
                    LifestyleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    doYouSmoke = table.Column<string>(type: "varchar(20)", nullable: true),
                    doYouIllegalDrugs = table.Column<string>(type: "varchar(20)", nullable: true),
                    doYouConsumeAlcohol = table.Column<string>(type: "varchar(20)", nullable: true),
                    Diet = table.Column<string>(type: "varchar(200)", nullable: true),
                    Exercise = table.Column<string>(type: "varchar(200)", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lifestyle", x => x.LifestyleID);
                    table.ForeignKey(
                        name: "FK_Lifestyle_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCoverage",
                columns: table => new
                {
                    MedicalCoverageID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasMedicalCoverage = table.Column<string>(type: "varchar(100)", nullable: true),
                    HealthCarePlan = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Coverage = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    HealthID = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCoverage", x => x.MedicalCoverageID);
                    table.ForeignKey(
                        name: "FK_MedicalCoverage_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phonenumbers",
                columns: table => new
                {
                    PhonenumbersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "varchar(200)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FamilyDoctorName = table.Column<string>(type: "varchar(200)", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonenumbers", x => x.PhonenumbersID);
                    table.ForeignKey(
                        name: "FK_Phonenumbers_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CovidHistoryRec",
                columns: table => new
                {
                    CovidHistoryRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CovidHistoryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CovidHistoryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidHistoryRec", x => x.CovidHistoryRecID);
                    table.ForeignKey(
                        name: "FK_CovidHistoryRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CovidHistoryRec_CovidHistory_CovidHistoryID1",
                        column: x => x.CovidHistoryID1,
                        principalTable: "CovidHistory",
                        principalColumn: "CovidHistoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrentMedicalConditionRec",
                columns: table => new
                {
                    CurrentMedicalConditionRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentMedicalConditionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentMedicalConditionID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMedicalConditionRec", x => x.CurrentMedicalConditionRecID);
                    table.ForeignKey(
                        name: "FK_CurrentMedicalConditionRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentMedicalConditionRec_CurrentMedicalCondition_CurrentMedicalConditionID1",
                        column: x => x.CurrentMedicalConditionID1,
                        principalTable: "CurrentMedicalCondition",
                        principalColumn: "CurrentMedicalConditionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMedicalHistoryRec",
                columns: table => new
                {
                    FamilyMedicalHistoryRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FamilyMedicalHistoryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyMedicalHistoryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMedicalHistoryRec", x => x.FamilyMedicalHistoryRecID);
                    table.ForeignKey(
                        name: "FK_FamilyMedicalHistoryRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyMedicalHistoryRec_FamilyMedicalHistory_FamilyMedicalHistoryID1",
                        column: x => x.FamilyMedicalHistoryID1,
                        principalTable: "FamilyMedicalHistory",
                        principalColumn: "FamilyMedicalHistoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientImmunizationRec",
                columns: table => new
                {
                    PatientImmunizationRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImmunizationID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImmunizationID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientImmunizationRec", x => x.PatientImmunizationRecID);
                    table.ForeignKey(
                        name: "FK_PatientImmunizationRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientImmunizationRec_Immunization_ImmunizationID1",
                        column: x => x.ImmunizationID1,
                        principalTable: "Immunization",
                        principalColumn: "ImmunizationID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedicalHistoryRec",
                columns: table => new
                {
                    PatientMedicalHistoryRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicalHistoryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalHistoryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedicalHistoryRec", x => x.PatientMedicalHistoryRecID);
                    table.ForeignKey(
                        name: "FK_PatientMedicalHistoryRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientMedicalHistoryRec_MedicalHistory_MedicalHistoryID1",
                        column: x => x.MedicalHistoryID1,
                        principalTable: "MedicalHistory",
                        principalColumn: "MedicalHistoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PastMedicalHistoryRec",
                columns: table => new
                {
                    PastMedicalHistoryRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastMedicalHistoryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastMedicalHistoryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastMedicalHistoryRec", x => x.PastMedicalHistoryRecID);
                    table.ForeignKey(
                        name: "FK_PastMedicalHistoryRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PastMedicalHistoryRec_PastMedicalHistory_PastMedicalHistoryID1",
                        column: x => x.PastMedicalHistoryID1,
                        principalTable: "PastMedicalHistory",
                        principalColumn: "PastMedicalHistoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientCountryRecord",
                columns: table => new
                {
                    PatientCountryRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvinceID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCountryRecord", x => x.PatientCountryRecordID);
                    table.ForeignKey(
                        name: "FK_PatientCountryRecord_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientCountryRecord_Country_CountryID1",
                        column: x => x.CountryID1,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientCountryRecord_Province_ProvinceID1",
                        column: x => x.ProvinceID1,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientProvinceRec",
                columns: table => new
                {
                    PatientProvinceRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CountryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProvinceRec", x => x.PatientProvinceRecID);
                    table.ForeignKey(
                        name: "FK_PatientProvinceRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientProvinceRec_Country_CountryID1",
                        column: x => x.CountryID1,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientProvinceRec_Province_ProvinceID1",
                        column: x => x.ProvinceID1,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "varchar(100)", nullable: true),
                    Province = table.Column<string>(type: "varchar(100)", nullable: true),
                    PatientProvinceRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    City = table.Column<string>(type: "varchar(100)", nullable: true),
                    AddressLineOne = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    AddressLineTwo = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.AddressID);
                    table.ForeignKey(
                        name: "FK_Address_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Address_PatientProvinceRec_PatientProvinceRecID",
                        column: x => x.PatientProvinceRecID,
                        principalTable: "PatientProvinceRec",
                        principalColumn: "PatientProvinceRecID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QRCode",
                columns: table => new
                {
                    QRCodeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QRCodeFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhonenumbersID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationUserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LifestyleID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QRCode", x => x.QRCodeID);
                    table.ForeignKey(
                        name: "FK_QRCode_Address_AddressID",
                        column: x => x.AddressID,
                        principalTable: "Address",
                        principalColumn: "AddressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QRCode_ApplicationUser_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "ApplicationUser",
                        principalColumn: "ApplicationUserID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QRCode_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QRCode_Lifestyle_LifestyleID",
                        column: x => x.LifestyleID,
                        principalTable: "Lifestyle",
                        principalColumn: "LifestyleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QRCode_Phonenumbers_PhonenumbersID",
                        column: x => x.PhonenumbersID,
                        principalTable: "Phonenumbers",
                        principalColumn: "PhonenumbersID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_AtomHealthUserID",
                table: "Address",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PatientProvinceRecID",
                table: "Address",
                column: "PatientProvinceRecID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_AtomHealthUserID",
                table: "ApplicationUser",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CovidHistoryRec_AtomHealthUserID",
                table: "CovidHistoryRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CovidHistoryRec_CovidHistoryID1",
                table: "CovidHistoryRec",
                column: "CovidHistoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMedicalConditionRec_AtomHealthUserID",
                table: "CurrentMedicalConditionRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMedicalConditionRec_CurrentMedicalConditionID1",
                table: "CurrentMedicalConditionRec",
                column: "CurrentMedicalConditionID1");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicalHistoryRec_AtomHealthUserID",
                table: "FamilyMedicalHistoryRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicalHistoryRec_FamilyMedicalHistoryID1",
                table: "FamilyMedicalHistoryRec",
                column: "FamilyMedicalHistoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_Lifestyle_AtomHealthUserID",
                table: "Lifestyle",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCoverage_AtomHealthUserID",
                table: "MedicalCoverage",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PastMedicalHistoryRec_AtomHealthUserID",
                table: "PastMedicalHistoryRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PastMedicalHistoryRec_PastMedicalHistoryID1",
                table: "PastMedicalHistoryRec",
                column: "PastMedicalHistoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCountryRecord_AtomHealthUserID",
                table: "PatientCountryRecord",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCountryRecord_CountryID1",
                table: "PatientCountryRecord",
                column: "CountryID1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCountryRecord_ProvinceID1",
                table: "PatientCountryRecord",
                column: "ProvinceID1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientImmunizationRec_AtomHealthUserID",
                table: "PatientImmunizationRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientImmunizationRec_ImmunizationID1",
                table: "PatientImmunizationRec",
                column: "ImmunizationID1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistoryRec_AtomHealthUserID",
                table: "PatientMedicalHistoryRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistoryRec_MedicalHistoryID1",
                table: "PatientMedicalHistoryRec",
                column: "MedicalHistoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProvinceRec_AtomHealthUserID",
                table: "PatientProvinceRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProvinceRec_CountryID1",
                table: "PatientProvinceRec",
                column: "CountryID1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProvinceRec_ProvinceID1",
                table: "PatientProvinceRec",
                column: "ProvinceID1");

            migrationBuilder.CreateIndex(
                name: "IX_Phonenumbers_AtomHealthUserID",
                table: "Phonenumbers",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_QRCode_AddressID",
                table: "QRCode",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_QRCode_ApplicationUserID",
                table: "QRCode",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_QRCode_AtomHealthUserID",
                table: "QRCode",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_QRCode_LifestyleID",
                table: "QRCode",
                column: "LifestyleID");

            migrationBuilder.CreateIndex(
                name: "IX_QRCode_PhonenumbersID",
                table: "QRCode",
                column: "PhonenumbersID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "CovidHistoryRec");

            migrationBuilder.DropTable(
                name: "CurrentMedicalConditionRec");

            migrationBuilder.DropTable(
                name: "FamilyMedicalHistoryRec");

            migrationBuilder.DropTable(
                name: "MedicalCoverage");

            migrationBuilder.DropTable(
                name: "PastMedicalHistoryRec");

            migrationBuilder.DropTable(
                name: "PatientCountryRecord");

            migrationBuilder.DropTable(
                name: "PatientImmunizationRec");

            migrationBuilder.DropTable(
                name: "PatientMedicalHistoryRec");

            migrationBuilder.DropTable(
                name: "QRCode");

            migrationBuilder.DropTable(
                name: "Subscribe");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CovidHistory");

            migrationBuilder.DropTable(
                name: "CurrentMedicalCondition");

            migrationBuilder.DropTable(
                name: "FamilyMedicalHistory");

            migrationBuilder.DropTable(
                name: "PastMedicalHistory");

            migrationBuilder.DropTable(
                name: "Immunization");

            migrationBuilder.DropTable(
                name: "MedicalHistory");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Lifestyle");

            migrationBuilder.DropTable(
                name: "Phonenumbers");

            migrationBuilder.DropTable(
                name: "PatientProvinceRec");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
