using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class AddConfigurationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ConfigId",
                table: "PoliciesCollection",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "ConfigurationConfigId",
                table: "PoliciesCollection",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    ConfigId = table.Column<byte>(type: "tinyint", nullable: false),
                    TimeLimit = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.ConfigId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesCollection_ConfigurationConfigId",
                table: "PoliciesCollection",
                column: "ConfigurationConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesCollection_Configuration_ConfigurationConfigId",
                table: "PoliciesCollection",
                column: "ConfigurationConfigId",
                principalTable: "Configuration",
                principalColumn: "ConfigId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesCollection_Configuration_ConfigurationConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesCollection_ConfigurationConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropColumn(
                name: "ConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropColumn(
                name: "ConfigurationConfigId",
                table: "PoliciesCollection");
        }
    }
}
