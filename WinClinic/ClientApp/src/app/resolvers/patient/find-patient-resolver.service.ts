import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { RegisterHttpService } from '../../http/register-http.service';
import { IPatients } from '../../model/IPatients';

@Injectable()
export class FindPatientResolverService implements Resolve<Observable<IPatients>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatients> {
    return this.http.find(route.paramMap.get('id') as string);
  }
  constructor(private http: RegisterHttpService) { }
}
