export interface IPatientLabs {
  patientLaboratoryServicesID: number;
  patientsID: string;
  laboratoryServicesID: number;
  receipt: string;
  results: string;
  requestingOfficer: string;
  dateRequested: Date;
  isServed: boolean;
  notes: string;
  accountsOfficer: string;
  amount: number;
  hasPaid: boolean;
  datePaid?: Date;
  labOfficer: string;
  dateServed?: Date;
  concurrency: number[];
  cost: number;
  labGroupsID: number;
  labsID: number;
  lab: string;
  groupName: string;
  patientAttendanceID: string;
}
