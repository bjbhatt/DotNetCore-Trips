using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Trips.Migrations.SalesDb
{
    public partial class CreateUpdateTimeStamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTimeStamp",
                schema: "dbo",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTimeStamp",
                schema: "dbo",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTimeStamp",
                schema: "dbo",
                table: "Orders",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTimeStamp",
                schema: "dbo",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTimeStamp",
                schema: "dbo",
                table: "OrderDetail",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTimeStamp",
                schema: "dbo",
                table: "OrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateTimeStamp",
                schema: "dbo",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateTimeStamp",
                schema: "dbo",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateTimeStamp",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateTimeStamp",
                schema: "dbo",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreateTimeStamp",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdateTimeStamp",
                schema: "dbo",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreateTimeStamp",
                schema: "dbo",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "UpdateTimeStamp",
                schema: "dbo",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "CreateTimeStamp",
                schema: "dbo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdateTimeStamp",
                schema: "dbo",
                table: "Customers");
        }
    }
}
