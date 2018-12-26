import { ILabGroups } from "./ILabGroups";

export interface ILaboratoryServices {
  laboratoryServicesID: number;
  laboratoryProcedure: string;
  ranges: string;
  labGroupsID: number;
  concurrency: any[];
  patientLaboratoryServices: any[];
  labGroups: ILabGroups;
  labGroup: string;
}
