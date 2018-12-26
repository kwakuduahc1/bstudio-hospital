import { ILaboratoryServices } from "./ILabServices";

export interface ILabGroups {
  labGroupsID: number;
  labGroup: string;
  cost: number;
  concurrency: number[];
  laboratoryServices: ILaboratoryServices[];
}
