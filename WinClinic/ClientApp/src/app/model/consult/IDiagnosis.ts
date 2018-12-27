export interface IDiagnoses {
  diagnosesID: string;
  diagnosis: string;
  description: string;
  concurrency: number[];
  dateAdded: Date;
  userName: string;
  diagnosticCodes: string;
}

export interface IDiagnosticCodes {
  diagnosticCodesID: string;
  gDRG: string;
  icdCode: string;
  description: string;
  schemesID: any;
  diagnosesID: string;
  tariff: number;
  patientDiagnoses: string;
  diagnosis: string;
  scheme: string;
}

export interface IPatientDiagnosis {
  patientDiagnosisID: string;
  patientAttendanceID: string;
  diagnosticCodesID: string;
  description: string;
  concurrency: number[];
  dateAdded: Date;
  userName: string;
  diagnosis: string;
  gDRG: string;
  icdCode: string;
}
