import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { ServicesHttpService } from "../../http/consulting/services-http.service";
import { IPatientServices } from "../../model/consult/IServices";

@Injectable()
export class PatientServicesResolver implements Resolve<Observable<IPatientServices[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatientServices[]> {
    return this.http.list(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: ServicesHttpService) { }
}
