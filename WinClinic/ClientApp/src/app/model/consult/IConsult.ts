import { ISigns } from "./ISigns";

export interface IConsultation {
  patientConsultationID: string;
  patientsID: string;
  complaints: string;
  physicianNotes: string;
  dateAdded: Date;
  userName: string;
  concurrency: number[];
  patientSigns: ISigns[];
  patientSymptoms: ISymptoms[];
  patientAttendanceID: string;
}
