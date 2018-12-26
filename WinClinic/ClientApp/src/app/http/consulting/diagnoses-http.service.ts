import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServerUrl } from './UrlService';
import {IPatientDiagnosis} from '../../model/consult/IPatientDiagnosis'

const url = ServerUrl;
@Injectable()
export class DiagnosesHttpService {


  add(item: IPatientDiagnosis): Observable<IPatientDiagnosis> {
    return this.http.post<IPatientDiagnosis>(`${url}Consult/Diagnose`, item);
  }

  edit(item: IPatientDiagnosis): Observable<IPatientDiagnosis> {
    return this.http.put<IPatientDiagnosis>(`${url}Consult/EditDiagnose`, item);
  }

  delete(item: IPatientDiagnosis): Observable<IPatientDiagnosis> {
    return this.http.post<IPatientDiagnosis>(`${url}Consult/DeleteDiagnose`, item);
  }

  find(id: string): Observable<IPatientDiagnosis> {
    return this.http.get<IPatientDiagnosis>(`${url}Consult/FindDiagnose?id=${id}`)
  }

  search(qry: string): Observable<IPatientDiagnosis[]> {
    throw new Error("Method not implemented.");
  }

  list(id: string, num: number = 10): Observable<IPatientDiagnosis[]> {
    return this.http.get<IPatientDiagnosis[]>(`${url}Consult/DiagnosesHistory?id=${id}&num=${num}`);
  }

  constructor(private http: HttpClient) { }
}
