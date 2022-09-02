using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class AddPolicyCommentListReference : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyComments_PoliciesCollection_PolicyColId",
                table: "PolicyComments");

            migrationBuilder.DropIndex(
                name: "IX_PolicyComments_PolicyColId",
                table: "PolicyComments");

            migrationBuilder.DropColumn(
                name: "PolicyColId",
                table: "PolicyComments");

            migrationBuilder.AddColumn<int>(
                name: "PolicyCollectionId",
                table: "PolicyComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyComments_PolicyCollectionId",
                table: "PolicyComments",
                column: "PolicyCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyComments_PoliciesCollection_PolicyCollectionId",
                table: "PolicyComments",
                column: "PolicyCollectionId",
                principalTable: "PoliciesCollection",
                principalColumn: "PolicyCollectionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PolicyComments_PoliciesCollection_PolicyCollectionId",
                table: "PolicyComments");

            migrationBuilder.DropIndex(
                name: "IX_PolicyComments_PolicyCollectionId",
                table: "PolicyComments");

            migrationBuilder.DropColumn(
                name: "PolicyCollectionId",
                table: "PolicyComments");

            migrationBuilder.AddColumn<int>(
                name: "PolicyColId",
                table: "PolicyComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyComments_PolicyColId",
                table: "PolicyComments",
                column: "PolicyColId");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyComments_PoliciesCollection_PolicyColId",
                table: "PolicyComments",
                column: "PolicyColId",
                principalTable: "PoliciesCollection",
                principalColumn: "PolicyCollectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
