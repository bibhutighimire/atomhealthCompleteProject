using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class changestwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyContactName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmergencyContactPhone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FamilyDoctorName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HomePhone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RelationshipToEmergencyContact",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Phonenumber",
                columns: table => new
                {
                    PhonenumberID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Phonenumber");

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactName",
                table: "AspNetUsers",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactPhone",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyDoctorName",
                table: "AspNetUsers",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhone",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RelationshipToEmergencyContact",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
