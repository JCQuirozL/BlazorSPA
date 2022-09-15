using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class FixConfigTableFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesCollection_TimeLimitConfiguration_ConfigurationConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesCollection_ConfigurationConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropColumn(
                name: "ConfigurationConfigId",
                table: "PoliciesCollection");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesCollection_TimeLimitConfiguration_ConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesCollection_ConfigId",
                table: "PoliciesCollection");

            migrationBuilder.AddColumn<byte>(
                name: "ConfigurationConfigId",
                table: "PoliciesCollection",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesCollection_ConfigurationConfigId",
                table: "PoliciesCollection",
                column: "ConfigurationConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesCollection_TimeLimitConfiguration_ConfigurationConfigId",
                table: "PoliciesCollection",
                column: "ConfigurationConfigId",
                principalTable: "TimeLimitConfiguration",
                principalColumn: "ConfigId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
