using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class changesseven : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCoverage_AtomHealthUserID",
                table: "MedicalCoverage",
                column: "AtomHealthUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalCoverage");
        }
    }
}
