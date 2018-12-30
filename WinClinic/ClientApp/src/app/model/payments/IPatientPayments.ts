import { IPatientDrugs } from "../consult/IPatientDrugs";
import { IPatientServices } from "../consult/IPatientServices";

export interface IPatientPayments {
  patientsID: string;
  fullName: string;
  isActive: boolean;
  drugs: IPatientDrugs[];
  services: IPatientServices[];
  groups: IGroups[];
  receipt: string;
  paymentMethod: string;
  amount: number;
  patientAttendanceID: string;
}
export interface ILabsVm {
  labsID: string;
  lab: string;
  amount: number;
  labGroupsID: number;
  attendanceID: any;
  patLabID: number;
}
export interface IGroups {
  labGroupsID: number;
  groupName: string;
  cost: number;
  labs: ILabsVm[];
  hasPaid: boolean;
}
