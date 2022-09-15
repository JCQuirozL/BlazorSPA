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
                    PolicyFileId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Policy = table.Column<string>(type: "varchar(50)", nullable: false),
                    TotalPremium = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Certificate = table.Column<string>(type: "varchar(15)", nullable: false),
                    Invoice = table.Column<string>(type: "varchar(15)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    EmmiterCenter = table.Column<string>(type: "varchar(5)", nullable: false),
                    InfoDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyCollectionFile", x => x.PolicyFileId);
                });

            migrationBuilder.CreateTable(
                name: "PolicyInformationService",
                columns: table => new
                {
                    PolicyInfoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Policy = table.Column<string>(type: "varchar(50)", nullable: false),
                    PaymentFolio = table.Column<string>(type: "varchar(50)", nullable: false),
                    Reference = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bank = table.Column<string>(type: "varchar(200)", nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    InfoDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
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
                    PolicyFileId = table.Column<long>(type: "bigint", nullable: false),
                    PolicyInfoId = table.Column<long>(type: "bigint", nullable: false),
                    Policy = table.Column<string>(type: "varchar(50)", nullable: false),
                    TotalPremium = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    PaymentFolio = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bank = table.Column<string>(type: "varchar(200)", nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ReferenceId = table.Column<string>(type: "varchar(50)", nullable: false),
                    Certificate = table.Column<string>(type: "varchar(15)", nullable: false),
                    Invoice = table.Column<string>(type: "varchar(15)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    EmmiterCenter = table.Column<string>(type: "varchar(5)", nullable: false),
                    Validated = table.Column<bool>(type: "bit", nullable: false),
                    ValidationDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "PoliciesCollectionHistory",
                columns: table => new
                {
                    PolicyCollectionHistoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyCollectionId = table.Column<int>(type: "int", nullable: false),
                    Policy = table.Column<string>(type: "varchar(50)", nullable: false),
                    TotalPremium = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    PaymentFolio = table.Column<string>(type: "varchar(50)", nullable: false),
                    Bank = table.Column<string>(type: "varchar(200)", nullable: false),
                    AccountNumber = table.Column<string>(type: "varchar(50)", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    DepositDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    ReferenceId = table.Column<string>(type: "varchar(50)", nullable: false),
                    Certificate = table.Column<string>(type: "varchar(15)", nullable: false),
                    Invoice = table.Column<string>(type: "varchar(15)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    EmmiterCenter = table.Column<string>(type: "varchar(5)", nullable: false),
                    Validated = table.Column<bool>(type: "bit", nullable: false),
                    ValidationDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliciesCollectionHistory", x => x.PolicyCollectionHistoryId);
                    table.ForeignKey(
                        name: "FK_PoliciesCollectionHistory_PoliciesCollection_PolicyCollectionId",
                        column: x => x.PolicyCollectionId,
                        principalTable: "PoliciesCollection",
                        principalColumn: "PolicyCollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolicyComments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyCollectionId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(30)", nullable: false),
                    CommentType = table.Column<string>(type: "varchar(30)", nullable: false),
                    CommentDate = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Comment = table.Column<string>(type: "varchar(250)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyComments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_PolicyComments_PoliciesCollection_PolicyCollectionId",
                        column: x => x.PolicyCollectionId,
                        principalTable: "PoliciesCollection",
                        principalColumn: "PolicyCollectionId",
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

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesCollectionHistory_PolicyCollectionId",
                table: "PoliciesCollectionHistory",
                column: "PolicyCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PolicyComments_PolicyCollectionId",
                table: "PolicyComments",
                column: "PolicyCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoliciesCollectionHistory");

            migrationBuilder.DropTable(
                name: "PolicyComments");

            migrationBuilder.DropTable(
                name: "PoliciesCollection");

            migrationBuilder.DropTable(
                name: "PolicyCollectionFile");

            migrationBuilder.DropTable(
                name: "PolicyInformationService");
        }
    }
}
