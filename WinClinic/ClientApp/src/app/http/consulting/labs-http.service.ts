import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPatientLabs } from '../../model/consult/IPatientLabs';
import { ServerUrl } from './UrlService';

const url = ServerUrl;
@Injectable()
export class LabsHttpService {


  add(item: IPatientLabs[]): Observable<IPatientLabs[]> {
    return this.http.post<IPatientLabs[]>(`${url}Consult/RequestLabs`, item);
  }

  edit(item: IPatientLabs): Observable<IPatientLabs> {
    return this.http.put<IPatientLabs>(`${url}Consult/Edit`, item);
  }

  delete(item: IPatientLabs): Observable<IPatientLabs[]> {
    return this.http.post<IPatientLabs[]>(`${url}Consult/DeleteLabs`, item);
  }

  find(id: string): Observable<IPatientLabs> {
    return this.http.get<IPatientLabs>(`${url}Consulting/Find?id=${id}`)
  }


  search(qry: string): Observable<IPatientLabs[]> {
    throw new Error("Method not implemented.");
  }

  list(id: string, num: number = 100): Observable<IPatientLabs[]> {
    return this.http.get<IPatientLabs[]>(`${url}Consult/LabHistory?id=${id}&num=${num}`);
  }
  constructor(private http: HttpClient) { }
}
