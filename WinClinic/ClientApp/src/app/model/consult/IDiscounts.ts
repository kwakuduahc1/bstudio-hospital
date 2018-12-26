export interface IPatientDiscounts {
  discountsID: string;
  patientsID: string;
  amount: number;
  discountDate: Date;
  concurrency: number[];
  officer: string;
  edit: number;
  show: boolean;
}
