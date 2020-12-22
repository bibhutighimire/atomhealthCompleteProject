using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class changessix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coverage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HealthCarePlan",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HealthID",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "BloodType",
                table: "AspNetUsers",
                type: "varchar(100)",
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
                name: "ImmunizationRecord",
                table: "AspNetUsers",
                type: "nvarchar(1000)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaritalStatus",
                table: "AspNetUsers",
                type: "varchar(100)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Diet",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Exercise",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImmunizationRecord",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Coverage",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthCarePlan",
                table: "AspNetUsers",
                type: "nvarchar(200)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthID",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                nullable: true);
        }
    }
}
