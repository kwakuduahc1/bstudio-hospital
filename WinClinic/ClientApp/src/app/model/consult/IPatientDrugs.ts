export interface IPatientDrugs {
  id: string;
  patientsID: string;
  drugsID: number;
  frequency: number;
  days: number;
  receipt: string;
  quantityRequested: number;
  quantityIssued: number;
  datePaid?: Date;
  hasPaid: boolean;
  receivingOfficer: string;
  isServed: boolean;
  dateServed?: Date;
  servingOficcer: string;
  dateRequested: Date;
  amountPaid: number;
  cost: number;
  requestingOfficer: string;
  concurrency: number[];
  quantity: number;
  isEdit: boolean;
  edit: number;
}
