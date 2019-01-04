import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPatients } from '../../model/IPatients';
import { ServerUrl } from '../consulting/UrlService';
import { IPatientServices } from '../../model/consult/IServices';

const url = ServerUrl;
@Injectable()
export class ServeServicesHttpService {


  add(item: IPatientServices[]): Observable<IPatientServices[]> {
    return this.http.post<IPatientServices[]>(`${url}Services/Serve`, item);
  }

  list(id: string): Observable<IPatientServices[]> {
    return this.http.get<IPatientServices[]>(`${url}Services/List?id=${id}`);
  }

  findPat(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Attendance/FindPatient?id=${id}`);
  }
  constructor(private http: HttpClient) { }
}
