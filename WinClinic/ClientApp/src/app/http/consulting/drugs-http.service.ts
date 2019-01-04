import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServerUrl } from './UrlService';
import { IPatientDrugs } from '../../model/consult/IPatientDrugs';
import { IPatients } from '../../model/IPatients';

const url = ServerUrl;
@Injectable()
export class DrugsHttpService {


  add(item: IPatientDrugs[]): Observable<IPatientDrugs[]> {
    return this.http.post<IPatientDrugs[]>(`${url}Dispensary/Dispense`, item);
  }

  edit(item: IPatientDrugs): Observable<IPatientDrugs> {
    return this.http.post<IPatientDrugs>(`${url}Consulting/EditRequestDrugs`, item);
  }

  delete(item: IPatientDrugs): Observable<IPatientDrugs> {
    return this.http.post<IPatientDrugs>(`${url}Consulting/DeleteDrug`, item);
  }

  find(id: string): Observable<IPatientDrugs> {
    return this.http.get<IPatientDrugs>(`${url}Consulting/Find?id=${id}`)
  }

  search(qry: string): Observable<IPatientDrugs[]> {
    throw new Error("Method not implemented.");
  }

  list(id: string): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>(`${url}Dispensary/Prescription?id=${id}`);
  }

  findPat(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/DrugQuantities/FindPatient?id=${id}`);
  }

  current(id: string, num: number = 50): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>(`${url}Consulting/CurrentDrugs?id=${id}`);
  }

  constructor(private http: HttpClient) { }
}
