import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServerUrl } from './UrlService';
import { IPatientFiles } from '../../model/consult/IPatientFiles';

const url = ServerUrl;
@Injectable()
export class FilesHttpService {


  add(item: IPatientFiles[]): Observable<IPatientFiles[]> {
    return this.http.post<IPatientFiles[]>(`${url}Consult/RequestDrugs`, item);
  }

  edit(item: IPatientFiles): Observable<IPatientFiles> {
    return this.http.put<IPatientFiles>(`${url}Consult/Edit`, item);
  }

  delete(item: IPatientFiles): Observable<IPatientFiles> {
    return this.http.post<IPatientFiles>(`${url}Consult/Delete`, item);
  }

  find(id: string): Observable<IPatientFiles> {
    return this.http.get<IPatientFiles>(`${url}Consulting/Find?id=${id}`)
  }

  search(qry: string): Observable<IPatientFiles[]> {
    throw new Error("Method not implemented.");
  }

  list(id: string, num: number = 10): Observable<IPatientFiles[]> {
    return this.http.get<IPatientFiles[]>(`${url}Consult/FileList?id=${id}&num=${num}`);
  }
  constructor(private http: HttpClient) { }
}
