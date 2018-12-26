export interface IDrugs {
  drugsID: number;
  drug: string;
  price: number;
  description: string;
  concurrency: number[];
  dateAdded: Date;
  patientDrugs: any[];
}
