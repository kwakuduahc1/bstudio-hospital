import { EVisitTypes } from "./EVisitTypes";

export interface IAttendance {
  iD: string;
  patientsID: string;
  visitType: EVisitTypes;
  dateSeen: Date;
  userName: string;
  concurrency: number[];
}
