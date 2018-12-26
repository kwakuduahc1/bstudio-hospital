import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IPatientDiagnosis } from "../../model/consult/IPatientDiagnosis";
import { DiagnosesHttpService } from "../../http/consulting/diagnoses-http.service";

@Injectable()
export class DiagnosesResolver implements Resolve<Observable<IPatientDiagnosis[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatientDiagnosis[]> {
    return this.http.list(route.parent!.paramMap.get('id') as string, 10);
  }

  constructor(private http: DiagnosesHttpService) { }
}
