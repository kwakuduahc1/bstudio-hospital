import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IHttpMethods } from '../model/IHttpMethods';
import { IOpd } from '../model/IOpd';

@Injectable()
export class OpdHttpService implements IHttpMethods<IOpd> {
  constructor(private http: HttpClient) {
  }

  list(id: string, num: number = 5): Observable<IOpd[]> {
    return this.http.get<IOpd[]>(`/Opd/List?id=${id}&num=${num}`);
  }

  add(pat: IOpd): Observable<IOpd> {
    return this.http.post<IOpd>(`/Opd/Create`, pat);
  }

  edit(pat: IOpd): Observable<IOpd> {
    return this.http.put<IOpd>(`/Opd/Edit`, pat);
  }

  delete(pat: IOpd): Observable<IOpd> {
    return this.http.post<IOpd>(`/Opd/Delete`, pat);
  }

  find(id: string): Observable<IOpd> {
    return this.http.get<IOpd>(`/Opd/Find?id=${id}`);
  }

  search(qry: string): Observable<IOpd[]> {
    return this.http.get<IOpd[]>(`/Opd/Search?name=${qry}`);
  }

}
