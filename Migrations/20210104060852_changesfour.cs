using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class changesfour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelationshipToEmergencyContact",
                table: "Phonenumbers");

            migrationBuilder.DropColumn(
                name: "Diet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Exercise",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "doYouConsumeAlcohol",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "doYouIllegalDrugs",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "doYouSmoke",
                table: "AspNetUsers");

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_AtomHealthUserID",
                table: "ApplicationUser",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lifestyle_AtomHealthUserID",
                table: "Lifestyle",
                column: "AtomHealthUserID",
                unique: true,
                filter: "[AtomHealthUserID] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Lifestyle");

            migrationBuilder.AddColumn<string>(
                name: "RelationshipToEmergencyContact",
                table: "Phonenumbers",
                type: "nvarchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Diet",
                table: "AspNetUsers",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exercise",
                table: "AspNetUsers",
                type: "varchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "AspNetUsers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "varchar(100)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "doYouConsumeAlcohol",
                table: "AspNetUsers",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "doYouIllegalDrugs",
                table: "AspNetUsers",
                type: "varchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "doYouSmoke",
                table: "AspNetUsers",
                type: "varchar(20)",
                nullable: true);
        }
    }
}
