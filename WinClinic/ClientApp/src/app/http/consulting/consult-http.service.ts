import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServerUrl } from './UrlService';
import { IConsultation } from '../../model/consult/IConsult';

const url = "/";
@Injectable()
export class ConsultHttpService {


  add(item: IConsultation): Observable<IConsultation> {
    return this.http.post<IConsultation>(`${url}Consult/Create`, item);
  }

  edit(item: IConsultation): Observable<IConsultation> {
    return this.http.put<IConsultation>(`${url}Consult/Edit`, item);
  }

  delete(item: IConsultation): Observable<IConsultation> {
    return this.http.post<IConsultation>(`${url}Consult/Delete`, item);
  }

  find(id: string): Observable<IConsultation> {
    return this.http.get<IConsultation>(`${url}Consult/Find?id=${id}`)
  }

  search(qry: string): Observable<IConsultation[]> {
    throw new Error("Method not implemented.");
  }

  list(id: string): Observable<IConsultation[]> {
    return this.http.get<IConsultation[]>(`${url}Consulting/ConsultHistory?id=${id}`);
  }

  constructor(private http: HttpClient) { }
}
