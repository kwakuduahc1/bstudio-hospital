import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IPatientLabs } from "../../model/consult/IPatientLabs";
import { LabsHttpService } from "../../http/consulting/labs-http.service";

@Injectable()
export class PatientLabsResolver implements Resolve<Observable<IPatientLabs[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatientLabs[]> {
    return this.http.list(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: LabsHttpService) { }
}
