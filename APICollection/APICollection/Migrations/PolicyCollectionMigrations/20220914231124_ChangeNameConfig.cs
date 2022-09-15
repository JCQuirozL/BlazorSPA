using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class ChangeNameConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesCollection_Configuration_ConfigurationConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Configuration",
                table: "Configuration");

            migrationBuilder.RenameTable(
                name: "Configuration",
                newName: "TimeLimitConfiguration");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PoliciesCollectionHistory",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PoliciesCollection",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TimeLimitConfiguration",
                table: "TimeLimitConfiguration",
                column: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesCollection_TimeLimitConfiguration_ConfigurationConfigId",
                table: "PoliciesCollection",
                column: "ConfigurationConfigId",
                principalTable: "TimeLimitConfiguration",
                principalColumn: "ConfigId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliciesCollection_TimeLimitConfiguration_ConfigurationConfigId",
                table: "PoliciesCollection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TimeLimitConfiguration",
                table: "TimeLimitConfiguration");

            migrationBuilder.RenameTable(
                name: "TimeLimitConfiguration",
                newName: "Configuration");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PoliciesCollectionHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PoliciesCollection",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Configuration",
                table: "Configuration",
                column: "ConfigId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliciesCollection_Configuration_ConfigurationConfigId",
                table: "PoliciesCollection",
                column: "ConfigurationConfigId",
                principalTable: "Configuration",
                principalColumn: "ConfigId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
