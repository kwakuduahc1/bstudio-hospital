import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { AttendanceHttpService } from '../../http/attendance-http-service';
import { IAttendanceVm } from '../../model/IAttendace';

@Injectable()
export class ActiveSessionResolverService implements Resolve<Observable<IAttendanceVm[]>> {
  resolve(): Observable<IAttendanceVm[]> {
    return this.http.sessions();
  }
  constructor(private http: AttendanceHttpService) { }
}
