import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPatients } from '../model/IPatients';
import { HttpClient } from '@angular/common/http';
import { IAttendanceVm, IAttendance } from '../model/IAttendace';

@Injectable()
export class AttendanceHttpService {

  list(num = 20): Observable<IAttendanceVm[]> {
    return this.http.get<IAttendanceVm[]>(`/Attendance/List?num=${num}`);
  }

  sessions(): Observable<IAttendanceVm[]> {
    return this.http.get<IAttendanceVm[]>("/Attendance/ActiveSessions")
  }

  close(att: IAttendanceVm): Observable<IAttendanceVm> {
    return this.http.post<IAttendanceVm>("/Attendance/CloseSession", att);
  }

  add(pat: IAttendance): Observable<IAttendance> {
    return this.http.post<IAttendance>(`/Attendance/Create`, pat);
  }

  edit(pat: IAttendance): Observable<IAttendance> {
    return this.http.post<IAttendance>(`/Attendance/Edit`, pat);
  }

  delete(pat: IAttendance): Observable<IAttendance> {
    return this.http.post<IAttendance>(`/Attendance/Delete`, pat);
  }

  find(id: string): Observable<IAttendance> {
    return this.http.get<IAttendance>(`/Attendance/Find?id=${id}`);
  }

  search(qry: string): Observable<IAttendanceVm[]> {
    return this.http.get<IAttendanceVm[]>(`/Attendance/Search?name=${qry}`);
  }

  findPat(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Attendance/FindPatient?id=${id}`);
  }

  patient(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Attendance/FindPatient?id=${id}`);
  }

  constructor(private http: HttpClient) { }
}
