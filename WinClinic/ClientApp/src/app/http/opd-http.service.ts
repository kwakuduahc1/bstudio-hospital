import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IOpd } from '../model/IOpd';
import { IPatients } from '../model/IPatients';

@Injectable()
export class OpdHttpService {
  constructor(private http: HttpClient) {
  }

  list(off = 0, num = 20): Observable<IOpd[]> {
    return this.http.get<IOpd[]>(`/VitalSigns/List?off=${off}&num=${num}`);
  }

  add(pat: IOpd): Observable<IOpd> {
    return this.http.post<IOpd>(`/VitalSigns/Create`, pat);
  }

  edit(pat: IOpd): Observable<IOpd> {
    return this.http.put<IOpd>(`/VitalSigns/Edit`, pat);
  }

  delete(pat: IOpd): Observable<IOpd> {
    return this.http.post<IOpd>(`/VitalSigns/Delete`, pat);
  }

  find(id: string): Observable<IOpd> {
    return this.http.get<IOpd>(`/VitalSigns/Find?id=${id}`);
  }

  findPat(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/VitalSigns/Patient?id=${id}`);
  }

  search(qry: string): Observable<IOpd[]> {
    return this.http.get<IOpd[]>(`/VitalSigns/Search?name=${qry}`);
  }

}
