import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IPatientDrugs } from "../../model/consult/IPatientDrugs";
import { DrugsHttpService } from "../../http/consulting/drugs-http.service";

@Injectable()
export class PatientDrugsResolver implements Resolve<Observable<IPatientDrugs[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatientDrugs[]> {
    return this.http.current(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: DrugsHttpService) { }
}
