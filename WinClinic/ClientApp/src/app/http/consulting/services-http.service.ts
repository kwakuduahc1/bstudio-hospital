import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServerUrl } from './UrlService';
import { IPatientServices } from '../../model/consult/IPatientServices';

const url = ServerUrl;
@Injectable()
export class ServicesHttpService {


  add(item: IPatientServices[]): Observable<IPatientServices[]> {
    return this.http.post<IPatientServices[]>(`${url}Consult/RequestService`, item);
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

  list(id: string, num: number = 50): Observable<IPatientServices[]> {
    return this.http.get<IPatientServices[]>(`${url}Consult/ServicesHistory?id=${id}&num=${num}`);
  }
  constructor(private http: HttpClient) { }
}
