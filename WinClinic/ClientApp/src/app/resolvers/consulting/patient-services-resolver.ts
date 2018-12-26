import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IPatientServices } from "../../model/consult/IPatientServices";
import { ServicesHttpService } from "../../http/consulting/services-http.service";

@Injectable()
export class PatientServicesResolver implements Resolve<Observable<IPatientServices[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatientServices[]> {
    return this.http.list(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: ServicesHttpService) { }
}
