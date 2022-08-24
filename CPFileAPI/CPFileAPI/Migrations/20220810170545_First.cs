using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPFileAPI.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoliciesCollectionFile",
                columns: table => new
                {
                    PolicyFileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalPremium = table.Column<decimal>(type: "decimal(14,2)", nullable: false),
                    Reference = table.Column<string>(type: "varchar(38)", maxLength: 38, nullable: false),
                    Policy = table.Column<string>(type: "varchar(10)", nullable: false),
                    Certificate = table.Column<string>(type: "varchar(10)", nullable: false),
                    Invoice = table.Column<string>(type: "varchar(10)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmitterCenter = table.Column<string>(type: "varchar(3)", nullable: false),
                    InfoDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliciesCollectionFile", x => x.PolicyFileId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoliciesCollectionFile");
        }
    }
}
