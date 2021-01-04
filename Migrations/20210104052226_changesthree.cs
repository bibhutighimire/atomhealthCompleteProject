using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class changesthree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phonenumber");

            migrationBuilder.CreateTable(
                name: "Phonenumbers",
                columns: table => new
                {
                    PhonenumbersID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HomePhone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "varchar(200)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RelationshipToEmergencyContact = table.Column<string>(type: "nvarchar(100)", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Phonenumbers_AtomHealthUserID",
                table: "Phonenumbers",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phonenumbers");

            migrationBuilder.CreateTable(
                name: "Phonenumber",
                columns: table => new
                {
                    PhonenumberID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmergencyContactName = table.Column<string>(type: "varchar(200)", nullable: true),
                    EmergencyContactPhone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    FamilyDoctorName = table.Column<string>(type: "varchar(200)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    RelationshipToEmergencyContact = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phonenumber", x => x.PhonenumberID);
                    table.ForeignKey(
                        name: "FK_Phonenumber_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Phonenumber_AtomHealthUserID",
                table: "Phonenumber",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");
        }
    }
}
