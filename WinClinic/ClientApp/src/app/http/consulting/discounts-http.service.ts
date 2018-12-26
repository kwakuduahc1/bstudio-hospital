import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ServerUrl } from './UrlService';
import { IPatientDiscounts } from '../../model/consult/IDiscounts';

const url = ServerUrl;
@Injectable()
export class DiscountsHttpService {


  add(item: IPatientDiscounts): Observable<IPatientDiscounts> {
    return this.http.post<IPatientDiscounts>(`${url}Discounts/Create`, item);
  }

  edit(item: IPatientDiscounts): Observable<IPatientDiscounts> {
    return this.http.post<IPatientDiscounts>(`${url}Discounts/Edit`, item);
  }

  delete(item: IPatientDiscounts): Observable<IPatientDiscounts> {
    return this.http.post<IPatientDiscounts>(`${url}Discounts/Delete`, item);
  }

  find(id: string): Observable<IPatientDiscounts> {
    return this.http.get<IPatientDiscounts>(`${url}Consulting/Find?id=${id}`)
  }

  search(qry: string): Observable<IPatientDiscounts[]> {
    throw new Error("Method not implemented.");
  }

  list(id: string, num: number = 50): Observable<IPatientDiscounts[]> {
    return this.http.get<IPatientDiscounts[]>(`${url}Discounts/List?id=${id}&num=${num}`);
  }

  constructor(private http: HttpClient) { }
}
