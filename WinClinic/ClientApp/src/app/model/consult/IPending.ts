export interface IPending {
  dateSeen: Date;
  diastolic?: number;
  opdID: string;
  otherNames: string;
  patientID: string;
  pulse?: number;
  respiration?: number;
  surname: string;
  systolic?: number;
  temperature: number;
  weight: number;
}
