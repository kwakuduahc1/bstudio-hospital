export interface IOpd {
  opdID: string;
  patientsID: string;
  history: string;
  systolic?: number;
  diastolic?: number;
  temperature: number;
  weight?: number;
  respiration?: number;
  pulse?: number;
  dateSeen: Date;
  userName: string;
  concurrency: number[];
}
