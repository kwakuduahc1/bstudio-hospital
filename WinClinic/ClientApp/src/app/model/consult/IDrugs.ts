export interface IDrugs {
  drugCodesID: string;
  drugsID: number;
  drugName: string;
  price: number;
  description: string;
  concurrency: number[];
  dateAdded: Date;
  patientDrugs: any[];
}
