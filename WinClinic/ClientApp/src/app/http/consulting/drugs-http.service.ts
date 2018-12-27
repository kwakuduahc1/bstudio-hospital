import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServerUrl } from './UrlService';
import { IPatientDrugs } from '../../model/consult/IPatientDrugs';

const url = ServerUrl;
@Injectable()
export class DrugsHttpService {


  add(item: IPatientDrugs[]): Observable<IPatientDrugs[]> {
    return this.http.post<IPatientDrugs[]>(`${url}Consult/RequestDrugs`, item);
  }

  edit(item: IPatientDrugs): Observable<IPatientDrugs> {
    return this.http.post<IPatientDrugs>(`${url}Consult/EditRequestDrugs`, item);
  }

  delete(item: IPatientDrugs): Observable<IPatientDrugs> {
    return this.http.post<IPatientDrugs>(`${url}Consult/DeleteDrug`, item);
  }

  find(id: string): Observable<IPatientDrugs> {
    return this.http.get<IPatientDrugs>(`${url}Consulting/Find?id=${id}`)
  }

  search(qry: string): Observable<IPatientDrugs[]> {
    throw new Error("Method not implemented.");
  }

  list(id: string, num: number = 50): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>(`${url}Consult/CurrentDrugHistory?id=${id}&num=${num}`);
  }

  constructor(private http: HttpClient) { }
}