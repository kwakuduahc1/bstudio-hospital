import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPatientLabs } from '../../model/consult/IPatientLabs';
import { ServerUrl } from './UrlService';

const url = ServerUrl;
@Injectable()
export class LabsHttpService {


  add(item: IPatientLabs[]): Observable<IPatientLabs[]> {
    return this.http.post<IPatientLabs[]>(`${url}Consulting/RequestLabs`, item);
  }

  edit(item: IPatientLabs): Observable<IPatientLabs> {
    return this.http.put<IPatientLabs>(`${url}Consulting/Edit`, item);
  }

  delete(item: IPatientLabs): Observable<IPatientLabs[]> {
    return this.http.post<IPatientLabs[]>(`${url}Consulting/DeleteLabs`, item);
  }

  find(id: string): Observable<IPatientLabs> {
    return this.http.get<IPatientLabs>(`${url}Consulting/Find?id=${id}`)
  }


  search(qry: string): Observable<IPatientLabs[]> {
    throw new Error("Method not implemented.");
  }

  list(id: string, num: number = 100): Observable<IPatientLabs[]> {
    return this.http.get<IPatientLabs[]>(`${url}Consulting/LabHistory?id=${id}&num=${num}`);
  }

  current(id: string): Observable<IPatientLabs[]> {
    return this.http.get<IPatientLabs[]>(`${url}Consulting/CurrentLabs?id=${id}`);
  }
  constructor(private http: HttpClient) { }
}
