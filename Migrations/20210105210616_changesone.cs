using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class changesone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_QRCode_AtomHealthUserID",
                table: "QRCode");

            migrationBuilder.DropColumn(
                name: "Allergies",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CovidDetails",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FamilyHistory",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "GeneticTest",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasAllergy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HasPastSurgery",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImmunizationRecord",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsInMedicaion",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MedicalConditions",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Medications",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PastMedicalHistoryDetails",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PastSurgeries",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "hasGeneticTest",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Dateofbirth",
                columns: table => new
                {
                    DateofbirthID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dateofbirth", x => x.DateofbirthID);
                    table.ForeignKey(
                        name: "FK_Dateofbirth_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicalRecord",
                columns: table => new
                {
                    MedicalRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    BloodType = table.Column<string>(type: "varchar(100)", nullable: true),
                    ImmunizationRecord = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalRecord", x => x.MedicalRecordID);
                    table.ForeignKey(
                        name: "FK_MedicalRecord_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QRCode_AtomHealthUserID",
                table: "QRCode",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Dateofbirth_AtomHealthUserID",
                table: "Dateofbirth",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecord_AtomHealthUserID",
                table: "MedicalRecord",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dateofbirth");

            migrationBuilder.DropTable(
                name: "MedicalRecord");

            migrationBuilder.DropIndex(
                name: "IX_QRCode_AtomHealthUserID",
                table: "QRCode");

            migrationBuilder.AddColumn<string>(
                name: "Allergies",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "AspNetUsers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CovidDetails",
                table: "AspNetUsers",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyHistory",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeneticTest",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HasAllergy",
                table: "AspNetUsers",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HasPastSurgery",
                table: "AspNetUsers",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImmunizationRecord",
                table: "AspNetUsers",
                type: "nvarchar(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IsInMedicaion",
                table: "AspNetUsers",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MedicalConditions",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Medications",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PastMedicalHistoryDetails",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PastSurgeries",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hasGeneticTest",
                table: "AspNetUsers",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QRCode_AtomHealthUserID",
                table: "QRCode",
                column: "AtomHealthUserID");
        }
    }
}
