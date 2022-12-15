using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class PoliciesHeaderInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PolicyHeaderInfoPolicyHeaderId",
                table: "PoliciesCollection",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PoliciesHeaderInfo",
                columns: table => new
                {
                    PolicyHeaderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentFolio = table.Column<string>(type: "varchar(50)", nullable: false),
                    DepositDate = table.Column<string>(type: "varchar(50)", nullable: false),
                    DepositAmount = table.Column<decimal>(type: "decimal(14,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliciesHeaderInfo", x => x.PolicyHeaderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoliciesCollection_PolicyHeaderInfoPolicyHeaderId",
                table: "PoliciesCollection",
                column: "PolicyHeaderInfoPolicyHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesCollection_PoliciesHeaderInfo_PolicyHeaderInfoPolicyHeaderId",
                table: "PoliciesCollection",
                column: "PolicyHeaderInfoPolicyHeaderId",
                principalTable: "PoliciesHeaderInfo",
                principalColumn: "PolicyHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesCollection_PoliciesHeaderInfo_PolicyHeaderInfoPolicyHeaderId",
                table: "PoliciesCollection");

            migrationBuilder.DropTable(
                name: "PoliciesHeaderInfo");

            migrationBuilder.DropIndex(
                name: "IX_PoliciesCollection_PolicyHeaderInfoPolicyHeaderId",
                table: "PoliciesCollection");

            migrationBuilder.DropColumn(
                name: "PolicyHeaderInfoPolicyHeaderId",
                table: "PoliciesCollection");
        }
    }
}
