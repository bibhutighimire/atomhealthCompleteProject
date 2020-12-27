using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AtomHealth.Migrations
{
    public partial class ctwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CovidHistory",
                columns: table => new
                {
                    CovidHistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CovidHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidHistory", x => x.CovidHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "CurrentMedicalCondition",
                columns: table => new
                {
                    CurrentMedicalConditionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentMedicalConditionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMedicalCondition", x => x.CurrentMedicalConditionID);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMedicalHistory",
                columns: table => new
                {
                    FamilyMedicalHistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FamilyMedicalHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMedicalHistory", x => x.FamilyMedicalHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "PastMedicalHistory",
                columns: table => new
                {
                    PastMedicalHistoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastMedicalHistoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    isChecked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastMedicalHistory", x => x.PastMedicalHistoryID);
                });

            migrationBuilder.CreateTable(
                name: "CovidHistoryRec",
                columns: table => new
                {
                    CovidHistoryRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CovidHistoryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CovidHistoryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CovidHistoryRec", x => x.CovidHistoryRecID);
                    table.ForeignKey(
                        name: "FK_CovidHistoryRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CovidHistoryRec_CovidHistory_CovidHistoryID1",
                        column: x => x.CovidHistoryID1,
                        principalTable: "CovidHistory",
                        principalColumn: "CovidHistoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CurrentMedicalConditionRec",
                columns: table => new
                {
                    CurrentMedicalConditionRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurrentMedicalConditionID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentMedicalConditionID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentMedicalConditionRec", x => x.CurrentMedicalConditionRecID);
                    table.ForeignKey(
                        name: "FK_CurrentMedicalConditionRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CurrentMedicalConditionRec_CurrentMedicalCondition_CurrentMedicalConditionID1",
                        column: x => x.CurrentMedicalConditionID1,
                        principalTable: "CurrentMedicalCondition",
                        principalColumn: "CurrentMedicalConditionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FamilyMedicalHistoryRec",
                columns: table => new
                {
                    FamilyMedicalHistoryRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FamilyMedicalHistoryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyMedicalHistoryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyMedicalHistoryRec", x => x.FamilyMedicalHistoryRecID);
                    table.ForeignKey(
                        name: "FK_FamilyMedicalHistoryRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FamilyMedicalHistoryRec_FamilyMedicalHistory_FamilyMedicalHistoryID1",
                        column: x => x.FamilyMedicalHistoryID1,
                        principalTable: "FamilyMedicalHistory",
                        principalColumn: "FamilyMedicalHistoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PastMedicalHistoryRec",
                columns: table => new
                {
                    PastMedicalHistoryRecID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PastMedicalHistoryID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PastMedicalHistoryID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AtomHealthUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PastMedicalHistoryRec", x => x.PastMedicalHistoryRecID);
                    table.ForeignKey(
                        name: "FK_PastMedicalHistoryRec_AspNetUsers_AtomHealthUserID",
                        column: x => x.AtomHealthUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PastMedicalHistoryRec_PastMedicalHistory_PastMedicalHistoryID1",
                        column: x => x.PastMedicalHistoryID1,
                        principalTable: "PastMedicalHistory",
                        principalColumn: "PastMedicalHistoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CovidHistoryRec_AtomHealthUserID",
                table: "CovidHistoryRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CovidHistoryRec_CovidHistoryID1",
                table: "CovidHistoryRec",
                column: "CovidHistoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMedicalConditionRec_AtomHealthUserID",
                table: "CurrentMedicalConditionRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentMedicalConditionRec_CurrentMedicalConditionID1",
                table: "CurrentMedicalConditionRec",
                column: "CurrentMedicalConditionID1");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicalHistoryRec_AtomHealthUserID",
                table: "FamilyMedicalHistoryRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMedicalHistoryRec_FamilyMedicalHistoryID1",
                table: "FamilyMedicalHistoryRec",
                column: "FamilyMedicalHistoryID1");

            migrationBuilder.CreateIndex(
                name: "IX_PastMedicalHistoryRec_AtomHealthUserID",
                table: "PastMedicalHistoryRec",
                column: "AtomHealthUserID");

            migrationBuilder.CreateIndex(
                name: "IX_PastMedicalHistoryRec_PastMedicalHistoryID1",
                table: "PastMedicalHistoryRec",
                column: "PastMedicalHistoryID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CovidHistoryRec");

            migrationBuilder.DropTable(
                name: "CurrentMedicalConditionRec");

            migrationBuilder.DropTable(
                name: "FamilyMedicalHistoryRec");

            migrationBuilder.DropTable(
                name: "PastMedicalHistoryRec");

            migrationBuilder.DropTable(
                name: "CovidHistory");

            migrationBuilder.DropTable(
                name: "CurrentMedicalCondition");

            migrationBuilder.DropTable(
                name: "FamilyMedicalHistory");

            migrationBuilder.DropTable(
                name: "PastMedicalHistory");
        }
    }
}
