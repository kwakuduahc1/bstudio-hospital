import { EVisitTypes } from "./EVisitTypes";

export interface IAttendance {
  id: string;
  patientsID: string;
  visitType: EVisitTypes;
  dateSeen: Date;
  userName: string;
  concurrency: number[];
  sessionName: string;
}

export interface IAttendanceVm {
  fullName: string;
  dateSeen: Date;
  visitType: string;
  patientsID: string;
  id: string;
  sessionName: string;
}
