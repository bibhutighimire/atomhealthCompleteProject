using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class cone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistoryRec_AtomHealthUserID",
                table: "PatientMedicalHistoryRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedicalHistoryRec_MedicalHistoryID1",
                table: "PatientMedicalHistoryRec",
                column: "MedicalHistoryID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientMedicalHistoryRec");

            migrationBuilder.DropTable(
                name: "MedicalHistory");
        }
    }
}
