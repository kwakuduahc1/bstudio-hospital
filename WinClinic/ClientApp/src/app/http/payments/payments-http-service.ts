import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPatients } from '../../model/IPatients';
import { IPatientPayments } from '../../model/payments/IPatientPayments';

@Injectable()
export class PaymnentsHttpService {

  list(id :string): Observable<IPatientPayments> {
    return this.http.get<IPatientPayments>(`/Payments/GetPayments?id=${id}`);
  }


  add(pay:IPatientPayments ): Observable<IPatientPayments> {
    return this.http.post<IPatientPayments>(`/Payments/Receive`, pay);
  }

  edit(pat: IPatientPayments): Observable<IPatientPayments> {
    return this.http.post<IPatientPayments>(`/Attendance/Edit`, pat);
  }

  delete(pat: IPatientPayments): Observable<IPatientPayments> {
    return this.http.post<IPatientPayments>(`/Attendance/Delete`, pat);
  }

  find(id: string): Observable<IPatientPayments> {
    return this.http.get<IPatientPayments>(`/Attendance/Find?id=${id}`);
  }

  findPat(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Attendance/FindPatient?id=${id}`);
  }

  patient(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Attendance/Patient?id=${id}`);
  }

  constructor(private http: HttpClient) { }
}
