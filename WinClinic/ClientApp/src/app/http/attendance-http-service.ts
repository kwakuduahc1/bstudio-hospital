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

  add(pat: IPatients): Observable<IAttendance> {
    return this.http.post<IAttendance>(`/Attendance/Create`, pat);
  }

  edit(pat: IPatients): Observable<IAttendance> {
    return this.http.post<IAttendance>(`/Attendance/Edit`, pat);
  }

  delete(pat: IPatients): Observable<IAttendance> {
    return this.http.post<IAttendance>(`/Attendance/Delete`, pat);
  }

  find(id: string): Observable<IAttendance> {
    return this.http.get<IAttendance>(`/Attendance/Find?id=${id}`);
  }

  search(qry: string): Observable<IAttendanceVm[]> {
    return this.http.get<IAttendanceVm[]>(`/Attendance/Search?name=${qry}`);
  }

  constructor(private http: HttpClient) { }
}
