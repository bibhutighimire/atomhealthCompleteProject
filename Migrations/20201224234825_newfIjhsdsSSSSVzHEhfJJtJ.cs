using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class newfIjhsdsSSSSVzHEhfJJtJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_PatientImmunizationRec_AtomHealthUserID",
                table: "PatientImmunizationRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientImmunizationRec_ImmunizationID1",
                table: "PatientImmunizationRec",
                column: "ImmunizationID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientImmunizationRec");

            migrationBuilder.DropTable(
                name: "Immunization");
        }
    }
}
