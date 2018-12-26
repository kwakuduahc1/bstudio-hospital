import { Injectable } from '@angular/core';
import { IPatients } from '../model/IPatients';

@Injectable()
export class PatientService {
  patient: IPatients | null;
  constructor() { }
}
