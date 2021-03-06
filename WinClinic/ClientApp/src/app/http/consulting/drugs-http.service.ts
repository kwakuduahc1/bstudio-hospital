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
    return this.http.post<IPatientDrugs[]>(`${url}Consulting/RequestDrugs`, item);
  }

  find(id: string): Observable<IPatientDrugs> {
    return this.http.get<IPatientDrugs>(`${url}Consulting/Find?id=${id}`)
  }

  list(id: string): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>(`${url}Consulting/Prescription?id=${id}`);
  }

  findPat(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Attendance/FindPatient?id=${id}`);
  }

  current(id: string, num: number = 50): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>(`${url}Consulting/CurrentDrugs?id=${id}`);
  }

  constructor(private http: HttpClient) { }
}
