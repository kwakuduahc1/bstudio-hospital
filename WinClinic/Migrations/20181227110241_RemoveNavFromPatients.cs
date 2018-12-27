using Microsoft.EntityFrameworkCore.Migrations;

namespace WinClinic.Migrations
{
    public partial class RemoveNavFromPatients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OpdHistory_Patients_PatientsID",
                table: "OpdHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientConsultations_Patients_PatientsID",
                table: "PatientConsultations");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDiagnosis_Patients_PatientsID",
                table: "PatientDiagnosis");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientDrugs_Patients_PatientsID",
                table: "PatientDrugs");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientLaboratoryServices_Patients_PatientsID",
                table: "PatientLaboratoryServices");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientServices_Patients_PatientsID",
                table: "PatientServices");

            migrationBuilder.DropIndex(
                name: "IX_PatientServices_PatientsID",
                table: "PatientServices");

            migrationBuilder.DropIndex(
                name: "IX_PatientLaboratoryServices_PatientsID",
                table: "PatientLaboratoryServices");

            migrationBuilder.DropIndex(
                name: "IX_PatientDrugs_PatientsID",
                table: "PatientDrugs");

            migrationBuilder.DropIndex(
                name: "IX_PatientDiagnosis_PatientsID",
                table: "PatientDiagnosis");

            migrationBuilder.DropIndex(
                name: "IX_PatientConsultations_PatientsID",
                table: "PatientConsultations");

            migrationBuilder.DropIndex(
                name: "IX_OpdHistory_PatientsID",
                table: "OpdHistory");

            migrationBuilder.DropColumn(
                name: "PatientsID",
                table: "PatientServices");

            migrationBuilder.DropColumn(
                name: "PatientsID",
                table: "PatientLaboratoryServices");

            migrationBuilder.DropColumn(
                name: "PatientsID",
                table: "PatientDrugs");

            migrationBuilder.DropColumn(
                name: "PatientsID",
                table: "PatientDiagnosis");

            migrationBuilder.DropColumn(
                name: "PatientsID",
                table: "PatientConsultations");

            migrationBuilder.DropColumn(
                name: "PatientsID",
                table: "OpdHistory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PatientsID",
                table: "PatientServices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientsID",
                table: "PatientLaboratoryServices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientsID",
                table: "PatientDrugs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientsID",
                table: "PatientDiagnosis",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientsID",
                table: "PatientConsultations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientsID",
                table: "OpdHistory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PatientServices_PatientsID",
                table: "PatientServices",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLaboratoryServices_PatientsID",
                table: "PatientLaboratoryServices",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDrugs_PatientsID",
                table: "PatientDrugs",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_PatientsID",
                table: "PatientDiagnosis",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientConsultations_PatientsID",
                table: "PatientConsultations",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_OpdHistory_PatientsID",
                table: "OpdHistory",
                column: "PatientsID");

            migrationBuilder.AddForeignKey(
                name: "FK_OpdHistory_Patients_PatientsID",
                table: "OpdHistory",
                column: "PatientsID",
                principalTable: "Patients",
                principalColumn: "PatientsID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientConsultations_Patients_PatientsID",
                table: "PatientConsultations",
                column: "PatientsID",
                principalTable: "Patients",
                principalColumn: "PatientsID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDiagnosis_Patients_PatientsID",
                table: "PatientDiagnosis",
                column: "PatientsID",
                principalTable: "Patients",
                principalColumn: "PatientsID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientDrugs_Patients_PatientsID",
                table: "PatientDrugs",
                column: "PatientsID",
                principalTable: "Patients",
                principalColumn: "PatientsID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLaboratoryServices_Patients_PatientsID",
                table: "PatientLaboratoryServices",
                column: "PatientsID",
                principalTable: "Patients",
                principalColumn: "PatientsID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientServices_Patients_PatientsID",
                table: "PatientServices",
                column: "PatientsID",
                principalTable: "Patients",
                principalColumn: "PatientsID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
