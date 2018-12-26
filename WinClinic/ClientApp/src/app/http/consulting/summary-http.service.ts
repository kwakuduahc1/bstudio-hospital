import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IVisitDate } from '../../model/consult/IVisitDates';
import { ServerUrl } from './UrlService';
import { ISummary } from '../../model/consult/ISummary';

const url = ServerUrl;
@Injectable()
export class SummarytHttpService {


  date(id: string, num = 5): Observable<IVisitDate[]> {
    return this.http.get<IVisitDate[]>(`${url}Consult/VisitDates?id=${id}&num=${num}`);
  }

  summary(id: string, date: Date): Observable<ISummary> {
    return this.http.get<ISummary>(`${url}/Consult/Summary?id=${id}&date=${date}`);
  }
  constructor(private http: HttpClient) { }
}
