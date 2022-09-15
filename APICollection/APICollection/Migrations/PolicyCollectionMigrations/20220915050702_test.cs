using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesCollection_TimeLimitConfiguration_ConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropTable(
                name: "TimeLimitConfiguration");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesCollection_ConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "PoliciesCollection");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ConfigId",
                table: "PoliciesCollection",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "TimeLimitConfiguration",
                columns: table => new
                {
                    ConfigId = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "varchar(50)", nullable: true),
                    TimeLimit = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeLimitConfiguration", x => x.ConfigId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesCollection_ConfigId",
                table: "PoliciesCollection",
                column: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesCollection_TimeLimitConfiguration_ConfigId",
                table: "PoliciesCollection",
                column: "ConfigId",
                principalTable: "TimeLimitConfiguration",
                principalColumn: "ConfigId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
