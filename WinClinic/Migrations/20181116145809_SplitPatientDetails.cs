using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinClinic.Migrations
{
    public partial class SplitPatientDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Schemes_SchemesID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DependentID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IsCapitated",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "IsDependent",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Kin",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "KinContact",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "SchemeNumber",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "Staff",
                newName: "Password");

            migrationBuilder.AlterColumn<Guid>(
                name: "SchemesID",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateTable(
                name: "PatientDetails",
                columns: table => new
                {
                    PatientsID = table.Column<string>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Kin = table.Column<string>(maxLength: 100, nullable: false),
                    KinContact = table.Column<string>(maxLength: 20, nullable: true),
                    IsDependent = table.Column<bool>(nullable: false),
                    DependentID = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    IsCapitated = table.Column<bool>(nullable: false),
                    SchemesID = table.Column<Guid>(nullable: false),
                    SchemeNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Town = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDetails", x => x.PatientsID);
                    table.ForeignKey(
                        name: "FK_PatientDetails_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Schemes_SchemesID",
                table: "Patients",
                column: "SchemesID",
                principalTable: "Schemes",
                principalColumn: "SchemesID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Schemes_SchemesID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "PatientDetails");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Staff",
                newName: "Branch");

            migrationBuilder.AlterColumn<Guid>(
                name: "SchemesID",
                table: "Patients",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Patients",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DependentID",
                table: "Patients",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCapitated",
                table: "Patients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDependent",
                table: "Patients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Kin",
                table: "Patients",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KinContact",
                table: "Patients",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchemeNumber",
                table: "Patients",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Patients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Patients",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Schemes_SchemesID",
                table: "Patients",
                column: "SchemesID",
                principalTable: "Schemes",
                principalColumn: "SchemesID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
