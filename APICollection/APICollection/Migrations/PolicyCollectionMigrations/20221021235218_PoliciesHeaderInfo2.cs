using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class PoliciesHeaderInfo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolicyHeaderId",
                table: "PoliciesCollection",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PolicyHeaderId",
                table: "PoliciesCollection");
        }
    }
}
