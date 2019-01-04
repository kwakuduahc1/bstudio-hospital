import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPatientDrugs } from '../../model/consult/IPatientDrugs';
import { IPatients } from '../../model/IPatients';
import { ServerUrl } from '../consulting/UrlService';

const url = ServerUrl;
@Injectable()
export class ServeDrugsHttpService {


  add(item: IPatientDrugs[]): Observable<IPatientDrugs[]> {
    return this.http.post<IPatientDrugs[]>(`${url}Dispensary/Dispense`, item);
  }

  list(id: string): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>(`${url}Dispensary/Prescription?id=${id}`);
  }

  findPat(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Attendance/FindPatient?id=${id}`);
  }
  constructor(private http: HttpClient) { }
}
