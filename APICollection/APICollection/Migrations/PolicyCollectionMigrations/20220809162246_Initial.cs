using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyCollectionFile",
                columns: table => new
                {
                    PolicyFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPremium = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Reference = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    Policy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Certificate = table.Column<int>(type: "int", nullable: false),
                    Invoice = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmitterCenter = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    InfoDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyCollectionFile", x => x.PolicyFileId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyInformationService",
                columns: table => new
                {
                    PolicyInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentFolio = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Bank = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Policy = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Certificate = table.Column<int>(type: "int", nullable: false),
                    Invoice = table.Column<int>(type: "int", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmitterCenter = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    InfoDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyInformationService", x => x.PolicyInfoId);
                });

            migrationBuilder.CreateTable(
                name: "PoliciesCollection",
                columns: table => new
                {
                    PolicyCollectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyFileId = table.Column<int>(type: "int", nullable: false),
                    PolicyInfoId = table.Column<int>(type: "int", nullable: false),
                    ValidationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DepositDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Validated = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliciesCollection", x => x.PolicyCollectionId);
                    table.ForeignKey(
                        name: "FK_PoliciesCollection_PolicyCollectionFile_PolicyFileId",
                        column: x => x.PolicyFileId,
                        principalTable: "PolicyCollectionFile",
                        principalColumn: "PolicyFileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoliciesCollection_PolicyInformationService_PolicyInfoId",
                        column: x => x.PolicyInfoId,
                        principalTable: "PolicyInformationService",
                        principalColumn: "PolicyInfoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesCollection_PolicyFileId",
                table: "PoliciesCollection",
                column: "PolicyFileId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesCollection_PolicyInfoId",
                table: "PoliciesCollection",
                column: "PolicyInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoliciesCollection");

            migrationBuilder.DropTable(
                name: "PolicyCollectionFile");

            migrationBuilder.DropTable(
                name: "PolicyInformationService");
        }
    }
}
