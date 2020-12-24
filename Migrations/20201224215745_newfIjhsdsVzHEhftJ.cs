using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class newfIjhsdsVzHEhftJ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImmunizationRecordCbox1",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImmunizationRecordCbox2",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImmunizationRecordCbox3",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImmunizationRecordCbox4",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImmunizationRecordCbox1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImmunizationRecordCbox2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImmunizationRecordCbox3",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ImmunizationRecordCbox4",
                table: "AspNetUsers");
        }
    }
}
