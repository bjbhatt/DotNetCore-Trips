using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trips.Migrations
{
    public partial class UpdateInstitute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDateTime",
                schema: "dbo",
                table: "Institutes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateUserNEDId",
                schema: "dbo",
                table: "Institutes",
                maxLength: 25,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDateTime",
                schema: "dbo",
                table: "Institutes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "dbo",
                table: "Institutes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StatusUpdateDateTime",
                schema: "dbo",
                table: "Institutes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_CreateUserNEDId",
                schema: "dbo",
                table: "Institutes",
                column: "CreateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes",
                column: "LastUpdateUserNEDId");

            migrationBuilder.CreateIndex(
                name: "IX_Institutes_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes",
                column: "StatusUpdateUserNEDId");

            migrationBuilder.AddForeignKey(
                name: "FK_Institutes_Users_CreateUserNEDId",
                schema: "dbo",
                table: "Institutes",
                column: "CreateUserNEDId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "NEDId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutes_Users_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes",
                column: "LastUpdateUserNEDId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "NEDId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Institutes_Users_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes",
                column: "StatusUpdateUserNEDId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "NEDId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Institutes_Users_CreateUserNEDId",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutes_Users_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropForeignKey(
                name: "FK_Institutes_Users_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropIndex(
                name: "IX_Institutes_CreateUserNEDId",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropIndex(
                name: "IX_Institutes_LastUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropIndex(
                name: "IX_Institutes_StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "CreateDateTime",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "CreateUserNEDId",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "LastUpdateDateTime",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "LastUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "StatusUpdateDateTime",
                schema: "dbo",
                table: "Institutes");

            migrationBuilder.DropColumn(
                name: "StatusUpdateUserNEDId",
                schema: "dbo",
                table: "Institutes");
        }
    }
}
