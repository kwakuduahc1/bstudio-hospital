import { IPatientDrugs } from "./IPatientDrugs";
import { IPatientLabs } from "./IPatientLabs";
import { IConsultation } from "./IConsult";
import { IPending } from "./IPending";
import { IPatientServices } from "./IServices";

export interface ISummary {
  drugs: IPatientDrugs[];
  services: IPatientServices[];
  labs: IPatientLabs[];
  hist: IConsultation[];
  opd: IPending[];
}
