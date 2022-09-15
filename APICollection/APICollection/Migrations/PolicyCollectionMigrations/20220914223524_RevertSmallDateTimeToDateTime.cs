using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class RevertSmallDateTimeToDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "PolicyInformationService",
                newName: "ReferenceId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InfoDate",
                table: "PolicyInformationService",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepositDate",
                table: "PolicyInformationService",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "PolicyComments",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "PolicyCollectionFile",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InfoDate",
                table: "PolicyCollectionFile",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidationDate",
                table: "PoliciesCollectionHistory",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PoliciesCollectionHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "PoliciesCollectionHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepositDate",
                table: "PoliciesCollectionHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PoliciesCollectionHistory",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidationDate",
                table: "PoliciesCollection",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PoliciesCollection",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "PoliciesCollection",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepositDate",
                table: "PoliciesCollection",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PoliciesCollection",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReferenceId",
                table: "PolicyInformationService",
                newName: "Reference");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InfoDate",
                table: "PolicyInformationService",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepositDate",
                table: "PolicyInformationService",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CommentDate",
                table: "PolicyComments",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "PolicyCollectionFile",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InfoDate",
                table: "PolicyCollectionFile",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidationDate",
                table: "PoliciesCollectionHistory",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PoliciesCollectionHistory",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "PoliciesCollectionHistory",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepositDate",
                table: "PoliciesCollectionHistory",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PoliciesCollectionHistory",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidationDate",
                table: "PoliciesCollection",
                type: "smalldatetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "PoliciesCollection",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "PoliciesCollection",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepositDate",
                table: "PoliciesCollection",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "PoliciesCollection",
                type: "smalldatetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
