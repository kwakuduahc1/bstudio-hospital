import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPatients } from '../model/IPatients';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class RegisterHttpService {

  list(num = 15, off = 0): Observable<IPatients[]> {
    return this.http.get<IPatients[]>(`/Registration/List?num=${num}&off=${off}`);
  }

  add(pat: IPatients): Observable<IPatients> {
    return this.http.post<IPatients>(`/Registration/Create`, pat);
  }

  edit(pat: IPatients): Observable<IPatients> {
    return this.http.post<IPatients>(`/Registration/Edit`, pat);
  }

  delete(pat: IPatients): Observable<IPatients> {
    return this.http.post<IPatients>(`/Registration/Delete`, pat);
  }

  find(id: string): Observable<IPatients> {
    return this.http.get<IPatients>(`/Registration/Find?id=${id}`);
  }

  search(qry: string): Observable<IPatients[]> {
    return this.http.get<IPatients[]>(`/Registration/Search?name=${qry}`);
  }

  constructor(private http: HttpClient) { }
}
