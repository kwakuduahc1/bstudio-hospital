export interface IPatients {
  patientsID: string;
  surname: string;
  otherNames: string;
  gender: string;
  dateOfBirth: Date;
  address: string;
  mobileNumber: string;
  town: string;
  kin: string;
  kinContact: string;
  dateAdded: Date;
  userName: string;
  isDependent: boolean;
  dependentID: string;
  status: boolean;
  isCapitated: boolean;
  schemesID: string;
  schemeNumber: string;
  concurrency: number[];
  fullName: string;
  scheme: string;
  patientAttendanceID: string;
}
