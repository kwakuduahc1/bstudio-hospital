using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WinClinic.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    DiagnosesID = table.Column<Guid>(nullable: false),
                    Diagnosis = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.DiagnosesID);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugsID = table.Column<Guid>(nullable: false),
                    DrugName = table.Column<string>(maxLength: 150, nullable: false),
                    GroupName = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugsID);
                });

            migrationBuilder.CreateTable(
                name: "LabGroups",
                columns: table => new
                {
                    LabGroupsID = table.Column<short>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GroupName = table.Column<string>(maxLength: 50, nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabGroups", x => x.LabGroupsID);
                });

            migrationBuilder.CreateTable(
                name: "Schemes",
                columns: table => new
                {
                    SchemesID = table.Column<Guid>(nullable: false),
                    Scheme = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schemes", x => x.SchemesID);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypesID = table.Column<Guid>(nullable: false),
                    ServiceType = table.Column<string>(maxLength: 30, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypesID);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    UserName = table.Column<string>(maxLength: 30, nullable: false),
                    Branch = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                columns: table => new
                {
                    WardName = table.Column<string>(maxLength: 50, nullable: false),
                    Capacity = table.Column<byte>(nullable: false),
                    PatientType = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.WardName);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryServices",
                columns: table => new
                {
                    LaboratoryServicesID = table.Column<Guid>(nullable: false),
                    LaboratoryProcedure = table.Column<string>(maxLength: 100, nullable: false),
                    LabGroupsID = table.Column<short>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryServices", x => x.LaboratoryServicesID);
                    table.ForeignKey(
                        name: "FK_LaboratoryServices_LabGroups_LabGroupsID",
                        column: x => x.LabGroupsID,
                        principalTable: "LabGroups",
                        principalColumn: "LabGroupsID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiagnosticCodes",
                columns: table => new
                {
                    DiagnosticCodesID = table.Column<Guid>(nullable: false),
                    GDRG = table.Column<string>(maxLength: 20, nullable: false),
                    ICDCode = table.Column<string>(maxLength: 15, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SchemesID = table.Column<Guid>(nullable: false),
                    DiagnosesID = table.Column<Guid>(nullable: false),
                    Tariff = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosticCodes", x => x.DiagnosticCodesID);
                    table.ForeignKey(
                        name: "FK_DiagnosticCodes_Diagnoses_DiagnosesID",
                        column: x => x.DiagnosesID,
                        principalTable: "Diagnoses",
                        principalColumn: "DiagnosesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnosticCodes_Schemes_SchemesID",
                        column: x => x.SchemesID,
                        principalTable: "Schemes",
                        principalColumn: "SchemesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugCodes",
                columns: table => new
                {
                    DrugCodesID = table.Column<Guid>(nullable: false),
                    DrugsID = table.Column<Guid>(nullable: false),
                    DrugCode = table.Column<string>(maxLength: 150, nullable: false),
                    SchemesID = table.Column<Guid>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugCodes", x => x.DrugCodesID);
                    table.ForeignKey(
                        name: "FK_DrugCodes_Drugs_DrugsID",
                        column: x => x.DrugsID,
                        principalTable: "Drugs",
                        principalColumn: "DrugsID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DrugCodes_Schemes_SchemesID",
                        column: x => x.SchemesID,
                        principalTable: "Schemes",
                        principalColumn: "SchemesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientsID = table.Column<string>(maxLength: 20, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: true),
                    OtherNames = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(maxLength: 6, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 20, nullable: false),
                    Town = table.Column<string>(maxLength: 200, nullable: false),
                    Kin = table.Column<string>(maxLength: 100, nullable: false),
                    KinContact = table.Column<string>(maxLength: 20, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    IsDependent = table.Column<bool>(nullable: false),
                    DependentID = table.Column<string>(maxLength: 20, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    IsCapitated = table.Column<bool>(nullable: false),
                    SchemesID = table.Column<Guid>(nullable: false),
                    SchemeNumber = table.Column<string>(maxLength: 20, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientsID);
                    table.ForeignKey(
                        name: "FK_Patients_Schemes_SchemesID",
                        column: x => x.SchemesID,
                        principalTable: "Schemes",
                        principalColumn: "SchemesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServicesID = table.Column<Guid>(nullable: false),
                    Service = table.Column<string>(maxLength: 200, nullable: false),
                    ServiceTypesID = table.Column<Guid>(nullable: false),
                    ServiceGroup = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServicesID);
                    table.ForeignKey(
                        name: "FK_Services_ServiceTypes_ServiceTypesID",
                        column: x => x.ServiceTypesID,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NursesWards",
                columns: table => new
                {
                    NursesWardsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 30, nullable: true),
                    WardName = table.Column<string>(nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursesWards", x => x.NursesWardsID);
                    table.ForeignKey(
                        name: "FK_NursesWards_Wards_WardName",
                        column: x => x.WardName,
                        principalTable: "Wards",
                        principalColumn: "WardName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpdHistory",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PatientsID = table.Column<string>(maxLength: 20, nullable: false),
                    History = table.Column<string>(maxLength: 500, nullable: true),
                    FirstAid = table.Column<string>(maxLength: 500, nullable: true),
                    Systolic = table.Column<double>(nullable: false),
                    Diastolic = table.Column<double>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    Pulse = table.Column<double>(nullable: false),
                    Respiration = table.Column<double>(nullable: false),
                    DateSeen = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpdHistory", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OpdHistory_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientAdmissions",
                columns: table => new
                {
                    PatientAdmissionsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientsID = table.Column<string>(nullable: false),
                    WardName = table.Column<string>(maxLength: 50, nullable: true),
                    DateAdmitted = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: true),
                    Discharged = table.Column<bool>(nullable: false),
                    DateDischarged = table.Column<DateTime>(nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAdmissions", x => x.PatientAdmissionsID);
                    table.ForeignKey(
                        name: "FK_PatientAdmissions_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientAdmissions_Wards_WardName",
                        column: x => x.WardName,
                        principalTable: "Wards",
                        principalColumn: "WardName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientAttendance",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PatientsID = table.Column<string>(maxLength: 20, nullable: false),
                    VisitType = table.Column<string>(maxLength: 15, nullable: false),
                    DateSeen = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientAttendance", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientAttendance_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientConsultations",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PatientsID = table.Column<string>(maxLength: 20, nullable: false),
                    Complaints = table.Column<string>(maxLength: 500, nullable: false),
                    Examination = table.Column<string>(maxLength: 500, nullable: true),
                    PhysicianNotes = table.Column<string>(maxLength: 500, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientConsultations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientConsultations_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientDiagnosis",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PatientsID = table.Column<string>(nullable: false),
                    DiagnosticCodesID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDiagnosis", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_DiagnosticCodes_DiagnosticCodesID",
                        column: x => x.DiagnosticCodesID,
                        principalTable: "DiagnosticCodes",
                        principalColumn: "DiagnosticCodesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDiagnosis_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.NoAction, onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientDrugs",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PatientsID = table.Column<string>(maxLength: 20, nullable: false),
                    DrugCodesID = table.Column<Guid>(nullable: false),
                    Frequency = table.Column<byte>(nullable: false),
                    NumberOfDays = table.Column<byte>(nullable: false),
                    Receipt = table.Column<string>(maxLength: 20, nullable: true),
                    QuantityRequested = table.Column<byte>(nullable: false),
                    QuantityIssued = table.Column<byte>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    ReceivingOficcer = table.Column<string>(maxLength: 30, nullable: true),
                    IsServed = table.Column<bool>(nullable: false),
                    DateServed = table.Column<DateTime>(nullable: false),
                    ServingOficcer = table.Column<string>(maxLength: 30, nullable: true),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    AmountPaid = table.Column<decimal>(nullable: false),
                    RequestingOficcer = table.Column<string>(maxLength: 30, nullable: true),
                    IsCompleted = table.Column<bool>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDrugs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientDrugs_DrugCodes_DrugCodesID",
                        column: x => x.DrugCodesID,
                        principalTable: "DrugCodes",
                        principalColumn: "DrugCodesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDrugs_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.NoAction, onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PatientLaboratoryServices",
                columns: table => new
                {
                    PatientLaboratoryServicesID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientsID = table.Column<string>(maxLength: 20, nullable: true),
                    LaboratoryServicesID = table.Column<Guid>(nullable: false),
                    Results = table.Column<string>(maxLength: 200, nullable: true),
                    RequestingOfficer = table.Column<string>(maxLength: 30, nullable: true),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    IsServed = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(maxLength: 100, nullable: true),
                    AccountsOfficer = table.Column<string>(maxLength: 30, nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: true),
                    LabOfficer = table.Column<string>(maxLength: 30, nullable: true),
                    DateServed = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientLaboratoryServices", x => x.PatientLaboratoryServicesID);
                    table.ForeignKey(
                        name: "FK_PatientLaboratoryServices_LaboratoryServices_LaboratoryServicesID",
                        column: x => x.LaboratoryServicesID,
                        principalTable: "LaboratoryServices",
                        principalColumn: "LaboratoryServicesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientLaboratoryServices_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientMedications",
                columns: table => new
                {
                    PatientMedicationsID = table.Column<Guid>(nullable: false),
                    PatientsID = table.Column<string>(nullable: false),
                    DrugName = table.Column<string>(maxLength: 500, nullable: false),
                    Frequency = table.Column<byte>(nullable: false),
                    NumberOfDays = table.Column<byte>(nullable: false),
                    Completed = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientMedications", x => x.PatientMedicationsID);
                    table.ForeignKey(
                        name: "FK_PatientMedications_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceCodes",
                columns: table => new
                {
                    ServiceCodesID = table.Column<Guid>(nullable: false),
                    ServiceCode = table.Column<string>(maxLength: 50, nullable: false),
                    SchemesID = table.Column<Guid>(nullable: false),
                    ServicesID = table.Column<Guid>(nullable: false),
                    Cost = table.Column<decimal>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCodes", x => x.ServiceCodesID);
                    table.ForeignKey(
                        name: "FK_ServiceCodes_Schemes_SchemesID",
                        column: x => x.SchemesID,
                        principalTable: "Schemes",
                        principalColumn: "SchemesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCodes_Services_ServicesID",
                        column: x => x.ServicesID,
                        principalTable: "Services",
                        principalColumn: "ServicesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdmissionInstructions",
                columns: table => new
                {
                    AdmissionInstructionsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientAdmissionsID = table.Column<long>(nullable: false),
                    Instructions = table.Column<string>(maxLength: 200, nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdmissionInstructions", x => x.AdmissionInstructionsID);
                    table.ForeignKey(
                        name: "FK_AdmissionInstructions_PatientAdmissions_PatientAdmissionsID",
                        column: x => x.PatientAdmissionsID,
                        principalTable: "PatientAdmissions",
                        principalColumn: "PatientAdmissionsID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DrugAdministrations",
                columns: table => new
                {
                    DrugAdministrationsID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PatientMedicationsID = table.Column<long>(nullable: false),
                    UserName = table.Column<string>(maxLength: 30, nullable: true),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true),
                    PatientMedicationsID1 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrugAdministrations", x => x.DrugAdministrationsID);
                    table.ForeignKey(
                        name: "FK_DrugAdministrations_PatientMedications_PatientMedicationsID1",
                        column: x => x.PatientMedicationsID1,
                        principalTable: "PatientMedications",
                        principalColumn: "PatientMedicationsID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatientServices",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PatientsID = table.Column<string>(maxLength: 20, nullable: true),
                    ServiceCodesID = table.Column<Guid>(nullable: false),
                    NumberOfDays = table.Column<byte>(nullable: false),
                    Frequency = table.Column<byte>(nullable: false),
                    RequestingOficcer = table.Column<string>(maxLength: 30, nullable: true),
                    ServiceCost = table.Column<decimal>(nullable: false),
                    DatePaid = table.Column<DateTime>(nullable: false),
                    IsPaid = table.Column<bool>(nullable: false),
                    ReceivingOficcer = table.Column<string>(maxLength: 30, nullable: true),
                    Receipt = table.Column<string>(maxLength: 15, nullable: true),
                    IsServed = table.Column<bool>(nullable: false),
                    DateServed = table.Column<DateTime>(nullable: false),
                    ServingOficcer = table.Column<string>(nullable: true),
                    DateRequested = table.Column<DateTime>(nullable: false),
                    Concurrency = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientServices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PatientServices_Patients_PatientsID",
                        column: x => x.PatientsID,
                        principalTable: "Patients",
                        principalColumn: "PatientsID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientServices_ServiceCodes_ServiceCodesID",
                        column: x => x.ServiceCodesID,
                        principalTable: "ServiceCodes",
                        principalColumn: "ServiceCodesID",
                        onDelete: ReferentialAction.Cascade, onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdmissionInstructions_PatientAdmissionsID",
                table: "AdmissionInstructions",
                column: "PatientAdmissionsID");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticCodes_DiagnosesID",
                table: "DiagnosticCodes",
                column: "DiagnosesID");

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosticCodes_SchemesID",
                table: "DiagnosticCodes",
                column: "SchemesID");

            migrationBuilder.CreateIndex(
                name: "IX_DrugAdministrations_PatientMedicationsID1",
                table: "DrugAdministrations",
                column: "PatientMedicationsID1");

            migrationBuilder.CreateIndex(
                name: "IX_DrugCodes_DrugsID",
                table: "DrugCodes",
                column: "DrugsID");

            migrationBuilder.CreateIndex(
                name: "IX_DrugCodes_SchemesID",
                table: "DrugCodes",
                column: "SchemesID");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryServices_LabGroupsID",
                table: "LaboratoryServices",
                column: "LabGroupsID");

            migrationBuilder.CreateIndex(
                name: "IX_NursesWards_WardName",
                table: "NursesWards",
                column: "WardName");

            migrationBuilder.CreateIndex(
                name: "IX_OpdHistory_PatientsID",
                table: "OpdHistory",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAdmissions_PatientsID",
                table: "PatientAdmissions",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAdmissions_WardName",
                table: "PatientAdmissions",
                column: "WardName");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAttendance_PatientsID",
                table: "PatientAttendance",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientConsultations_PatientsID",
                table: "PatientConsultations",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_DiagnosticCodesID",
                table: "PatientDiagnosis",
                column: "DiagnosticCodesID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDiagnosis_PatientsID",
                table: "PatientDiagnosis",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDrugs_DrugCodesID",
                table: "PatientDrugs",
                column: "DrugCodesID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDrugs_PatientsID",
                table: "PatientDrugs",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLaboratoryServices_LaboratoryServicesID",
                table: "PatientLaboratoryServices",
                column: "LaboratoryServicesID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLaboratoryServices_PatientsID",
                table: "PatientLaboratoryServices",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientMedications_PatientsID",
                table: "PatientMedications",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SchemesID",
                table: "Patients",
                column: "SchemesID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientServices_PatientsID",
                table: "PatientServices",
                column: "PatientsID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientServices_ServiceCodesID",
                table: "PatientServices",
                column: "ServiceCodesID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCodes_SchemesID",
                table: "ServiceCodes",
                column: "SchemesID");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCodes_ServicesID",
                table: "ServiceCodes",
                column: "ServicesID");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceTypesID",
                table: "Services",
                column: "ServiceTypesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdmissionInstructions");

            migrationBuilder.DropTable(
                name: "DrugAdministrations");

            migrationBuilder.DropTable(
                name: "NursesWards");

            migrationBuilder.DropTable(
                name: "OpdHistory");

            migrationBuilder.DropTable(
                name: "PatientAttendance");

            migrationBuilder.DropTable(
                name: "PatientConsultations");

            migrationBuilder.DropTable(
                name: "PatientDiagnosis");

            migrationBuilder.DropTable(
                name: "PatientDrugs");

            migrationBuilder.DropTable(
                name: "PatientLaboratoryServices");

            migrationBuilder.DropTable(
                name: "PatientServices");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "PatientAdmissions");

            migrationBuilder.DropTable(
                name: "PatientMedications");

            migrationBuilder.DropTable(
                name: "DiagnosticCodes");

            migrationBuilder.DropTable(
                name: "DrugCodes");

            migrationBuilder.DropTable(
                name: "LaboratoryServices");

            migrationBuilder.DropTable(
                name: "ServiceCodes");

            migrationBuilder.DropTable(
                name: "Wards");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Drugs");

            migrationBuilder.DropTable(
                name: "LabGroups");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Schemes");

            migrationBuilder.DropTable(
                name: "ServiceTypes");
        }
    }
}
