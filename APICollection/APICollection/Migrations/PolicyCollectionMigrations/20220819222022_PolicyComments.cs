using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class PolicyComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PolicyComments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyColId = table.Column<int>(type: "int", nullable: false),
                    User = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CommentType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolicyComments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_PolicyComments_PoliciesCollection_PolicyColId",
                        column: x => x.PolicyColId,
                        principalTable: "PoliciesCollection",
                        principalColumn: "PolicyCollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PolicyComments_PolicyColId",
                table: "PolicyComments",
                column: "PolicyColId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PolicyComments");
        }
    }
}
