﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICollection.Migrations.PolicyCollectionMigrations
{
    public partial class InversePropertyConfigurated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PolicyCollectionId",
                table: "PolicyComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PolicyComments_PolicyCollectionId",
                table: "PolicyComments",
                column: "PolicyCollectionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PolicyComments_PoliciesCollection_PolicyCollectionId",
                table: "PolicyComments",
                column: "PolicyCollectionId",
                principalTable: "PoliciesCollection",
                principalColumn: "PolicyCollectionId",
                onDelete: ReferentialAction.Cascade);
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
    }
}