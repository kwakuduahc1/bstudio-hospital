import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServerUrl } from './UrlService';
import { IPatientDiagnosis, IDiagnosticCodes } from '../../model/consult/IDiagnosis';

const url = ServerUrl;
@Injectable()
export class DiagnosesHttpService {


  add(item: IPatientDiagnosis[]): Observable<IPatientDiagnosis[]> {
    return this.http.post<IPatientDiagnosis[]>(`${url}Consulting/Diagnose`, item);
  }

  edit(item: IPatientDiagnosis): Observable<IPatientDiagnosis> {
    return this.http.put<IPatientDiagnosis>(`${url}Consulting/EditDiagnose`, item);
  }

  delete(item: IPatientDiagnosis): Observable<IPatientDiagnosis> {
    return this.http.post<IPatientDiagnosis>(`${url}Consulting/DeleteDiagnose`, item);
  }

  find(id: string): Observable<IPatientDiagnosis> {
    return this.http.get<IPatientDiagnosis>(`${url}Consulting/FindDiagnose?id=${id}`)
  }

  search(qry: string): Observable<IPatientDiagnosis[]> {
    throw new Error("Method not implemented.");
  }

  patientList(id: string, num: number = 10): Observable<IPatientDiagnosis[]> {
    return this.http.get<IPatientDiagnosis[]>(`${url}Consulting/DiagnosesHistory?id=${id}&num=${num}`);
  }

  schemeList(id: string): Observable<IDiagnosticCodes[]> {
    return this.http.get<IDiagnosticCodes[]>(`/Consulting/SchemeDiagnoses?id=${id}`)
  }
  constructor(private http: HttpClient) { }
}
