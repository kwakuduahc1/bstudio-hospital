import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPatientDrugs } from '../../model/consult/IPatientDrugs';
import { IPatients } from '../../model/IPatients';

@Injectable()
export class DrugQuantitiesHttpService {

  get(id:string): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>(`/DrugQuantities/GetPrescriptions?id=${id}`);
  }

  set(pat: IPatientDrugs[]): Observable<IPatientDrugs[]> {
    return this.http.post<IPatientDrugs[]>(`/DrugQuantities/Set`, pat);
  }

  dispense(pat: IPatientDrugs[]): Observable<IPatientDrugs[]> {
    return this.http.post<IPatientDrugs[]>(`/DrugQuantities/Dispense`, pat);
  }

  find(id: string): Observable<IPatientDrugs> {
    return this.http.get<IPatientDrugs>(`/DrugQuantities/Find?id=${id}`);
  }

  findPat(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/DrugQuantities/FindPatient?id=${id}`);
  }

  patient(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/DrugQuantities/FindPatient?id=${id}`);
  }

  constructor(private http: HttpClient) { }
}
