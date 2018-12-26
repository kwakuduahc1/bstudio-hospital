import { IServices } from "./IServices";

export interface IPatientServices {
  patientServicesID: string;
  patientsID: string;
  servicesID: number;
  frequency: number;
  requestingOfficer: string;
  serviceCost: number;
  datePaid?: Date;
  hasPaid: boolean;
  receivingOficcer: string;
  receipt: string;
  isServed: boolean;
  report: string;
  dateServed?: Date;
  servingOficcer: string;
  dateRequested: Date;
  concurrency: number[];
  services: IServices;
}
