using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinClinic.Migrations
{
    public partial class InactivateVisit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateClosed",
                table: "PatientAttendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PatientAttendance",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateClosed",
                table: "PatientAttendance");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PatientAttendance");
        }
    }
}
