using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class cthree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PastMedicalHistory",
                table: "AspNetUsers",
                newName: "PastMedicalHistoryDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PastMedicalHistoryDetails",
                table: "AspNetUsers",
                newName: "PastMedicalHistory");
        }
    }
}
