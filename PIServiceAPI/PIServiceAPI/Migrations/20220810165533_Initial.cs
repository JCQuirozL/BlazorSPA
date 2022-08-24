using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PIServiceAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PoliciesInformationService",
                columns: table => new
                {
                    PolicyInfoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentFolio = table.Column<string>(type: "varchar(10)", nullable: false),
                    Bank = table.Column<string>(type: "varchar(30)", nullable: false),
                    Policy = table.Column<string>(type: "varchar(10)", nullable: false),
                    Certificate = table.Column<string>(type: "varchar(10)", nullable: false),
                    Invoice = table.Column<string>(type: "varchar(10)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmitterCenter = table.Column<string>(type: "varchar(3)", nullable: false),
                    InfoDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliciesInformationService", x => x.PolicyInfoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoliciesInformationService");
        }
    }
}
