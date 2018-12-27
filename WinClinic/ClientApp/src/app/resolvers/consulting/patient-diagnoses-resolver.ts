import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { DiagnosesHttpService } from "../../http/consulting/diagnoses-http.service";
import { IPatientDiagnosis } from "../../model/consult/IDiagnosis";

@Injectable()
export class PatientDiagnosesResolver implements Resolve<Observable<IPatientDiagnosis[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatientDiagnosis[]> {
    return this.http.patientList(route.parent!.paramMap.get('id') as string, 10);
  }

  constructor(private http: DiagnosesHttpService) { }
}
