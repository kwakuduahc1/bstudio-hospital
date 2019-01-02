import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPatientDrugs } from '../../model/consult/IPatientDrugs';
import { IPatients } from '../../model/IPatients';

@Injectable()
export class DrugQuantitiesHttpService {

  list(num = 20): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>(`/Attendance/List?num=${num}`);
  }

  sessions(): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>("/Attendance/ActiveSessions")
  }

  close(att: IPatientDrugs): Observable<IPatientDrugs> {
    return this.http.post<IPatientDrugs>("/Attendance/CloseSession", att);
  }

  add(pat: IPatientDrugs): Observable<IPatientDrugs> {
    return this.http.post<IPatientDrugs>(`/Attendance/Create`, pat);
  }

  edit(pat: IPatientDrugs): Observable<IPatientDrugs> {
    return this.http.post<IPatientDrugs>(`/Attendance/Edit`, pat);
  }

  delete(pat: IPatientDrugs): Observable<IPatientDrugs> {
    return this.http.post<IPatientDrugs>(`/Attendance/Delete`, pat);
  }

  find(id: string): Observable<IPatientDrugs> {
    return this.http.get<IPatientDrugs>(`/Attendance/Find?id=${id}`);
  }

  search(qry: string): Observable<IPatientDrugs[]> {
    return this.http.get<IPatientDrugs[]>(`/Attendance/Search?name=${qry}`);
  }

  findPat(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Attendance/FindPatient?id=${id}`);
  }

  patient(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Attendance/FindPatient?id=${id}`);
  }

  constructor(private http: HttpClient) { }
}
