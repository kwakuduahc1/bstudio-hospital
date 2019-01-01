import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServerUrl } from './UrlService';
import { IPatientServices } from '../../model/consult/IServices';

const url = ServerUrl;
@Injectable()
export class ServicesHttpService {


  add(item: IPatientServices[]): Observable<IPatientServices[]> {
    return this.http.post<IPatientServices[]>(`${url}Consulting/RequestServices`, item);
  }

  edit(item: IPatientServices): Observable<IPatientServices> {
    return this.http.put<IPatientServices>(`${url}Consult/Edit`, item);
  }

  delete(item: IPatientServices): Observable<IPatientServices> {
    return this.http.post<IPatientServices>(`${url}PatientServices/Delete`, item);
  }

  find(id: string): Observable<IPatientServices> {
    return this.http.get<IPatientServices>(`${url}Consulting/Find?id=${id}`)
  }


  search(qry: string): Observable<IPatientServices[]> {
    throw new Error("Method not implemented.");
  }

  list(id: string): Observable<IPatientServices[]> {
    return this.http.get<IPatientServices[]>(`${url}Consulting/ServicesHistory?id=${id}`);
  }
  constructor(private http: HttpClient) { }
}
