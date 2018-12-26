import { IPatientDrugs } from "./IPatientDrugs";
import { IPatientServices } from "./IPatientServices";
import { IPatientLabs } from "./IPatientLabs";
import { IConsultation } from "./IConsult";
import { IPending } from "./IPending";

export interface ISummary {
  drugs: IPatientDrugs[];
  services: IPatientServices[];
  labs: IPatientLabs[];
  hist: IConsultation[];
  opd: IPending[];
}
