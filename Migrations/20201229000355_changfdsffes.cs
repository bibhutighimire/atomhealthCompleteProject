using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class changfdsffes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "PatientCountryRecord",
                columns: table => new
                {
                    PatientCountryRecordID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProvinceID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientCountryRecord", x => x.PatientCountryRecordID);
                    table.ForeignKey(
                        name: "FK_PatientCountryRecord_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientCountryRecord_Country_CountryID1",
                        column: x => x.CountryID1,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientCountryRecord_Province_ProvinceID1",
                        column: x => x.ProvinceID1,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientProvinceRec",
                columns: table => new
                {
                    PatientProvinceRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CountryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientProvinceRec", x => x.PatientProvinceRecID);
                    table.ForeignKey(
                        name: "FK_PatientProvinceRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientProvinceRec_Country_CountryID1",
                        column: x => x.CountryID1,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientProvinceRec_Province_ProvinceID1",
                        column: x => x.ProvinceID1,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientCountryRecord_AtomHealthUserID",
                table: "PatientCountryRecord",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCountryRecord_CountryID1",
                table: "PatientCountryRecord",
                column: "CountryID1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientCountryRecord_ProvinceID1",
                table: "PatientCountryRecord",
                column: "ProvinceID1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProvinceRec_AtomHealthUserID",
                table: "PatientProvinceRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProvinceRec_CountryID1",
                table: "PatientProvinceRec",
                column: "CountryID1");

            migrationBuilder.CreateIndex(
                name: "IX_PatientProvinceRec_ProvinceID1",
                table: "PatientProvinceRec",
                column: "ProvinceID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientCountryRecord");

            migrationBuilder.DropTable(
                name: "PatientProvinceRec");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Province");
        }
    }
}
