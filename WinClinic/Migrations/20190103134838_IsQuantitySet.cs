using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinClinic.Migrations
{
    public partial class IsQuantitySet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateQuantitySet",
                table: "PatientDrugs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsQuantitySet",
                table: "PatientDrugs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateQuantitySet",
                table: "PatientDrugs");

            migrationBuilder.DropColumn(
                name: "IsQuantitySet",
                table: "PatientDrugs");
        }
    }
}
