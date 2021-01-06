using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class changesthree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeightMeasure",
                table: "ApplicationUser",
                type: "varchar(10)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeightMeasure",
                table: "ApplicationUser",
                type: "varchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HeightMeasure",
                table: "ApplicationUser");

            migrationBuilder.DropColumn(
                name: "WeightMeasure",
                table: "ApplicationUser");
        }
    }
}
