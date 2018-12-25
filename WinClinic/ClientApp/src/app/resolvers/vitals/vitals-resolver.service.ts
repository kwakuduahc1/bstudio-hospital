import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { OpdHttpService } from '../../http/opd-http.service';
import { IOpd } from '../../model/IOpd';

@Injectable()
export class VitalsResolverService implements Resolve<Observable<IOpd[]>> {
  resolve(): Observable<IOpd[]> {
    return this.http.list();
  }
  constructor(private http: OpdHttpService) { }
}
