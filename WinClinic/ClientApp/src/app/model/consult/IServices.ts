import { IPatientServices } from "./IPatientServices";

export interface IServices {
  servicesID: number;
  service: string;
  cost: number;
  serviceGroup: string;
  concurrency: number[];
  patientServices: IPatientServices[];
}
