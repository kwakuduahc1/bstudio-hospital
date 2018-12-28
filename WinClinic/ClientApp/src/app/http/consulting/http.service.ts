import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPending } from '../../model/consult/IPending';
import { ServerUrl } from './UrlService';
import { IPatients } from '../../model/IPatients';
import { IDrugs } from '../../model/consult/IDrugs';
import { IServices } from '../../model/consult/IServices';
import { ISummary } from '../../model/consult/ISummary';
import { IStaff } from '../../model/IStaff';
import { ILabGroups } from '../../model/consult/ILabGroups'

const url = ServerUrl;
@Injectable()
export class HttpService {

  list(): Observable<IPending[]> {
    return this.http.get<IPending[]>(`${url}Consulting/Pending`);
  }

  find(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`${url}Attendance/Patient?id=${id}`);
  }

  labGroups(): Observable<ILabGroups[]> {
    return this.http.get<ILabGroups[]>(`${url}Consulting/SchemeLabs`);
  }

  drugs(id:string): Observable<IDrugs[]> {
    return this.http.get<IDrugs[]>(`${url}Consulting/SchemeDrugs?id=${id}`);
  }

  services(): Observable<IServices[]> {
    return this.http.get<IServices[]>(`${url}Consulting/Services`);
  }

  summary(id: string): Observable<ISummary[]> {
    return this.http.get<ISummary[]>(`${url}Consulting/Summary?id=${id}`);
  }

  vitals(id: string): Observable<any[]> {
    return this.http.get<any[]>(`${url}Consulting/Vitals?id=${id}`);
  }

  login(st: any): Observable<IStaff> {
    return this.http.post<IStaff>(`${url}Staff/Login`, st)
  }

  constructor(private http: HttpClient) { }
}
