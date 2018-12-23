import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { IPatients } from '../../model/IPatients';
import { RegisterHttpService } from '../../http/register-http.service';

@Injectable()
export class PatientsResolverService implements Resolve<Observable<IPatients[]>> {
  resolve(): Observable<IPatients[]> {
    return this.http.list();
  }
  constructor(private http: RegisterHttpService) { }
}
