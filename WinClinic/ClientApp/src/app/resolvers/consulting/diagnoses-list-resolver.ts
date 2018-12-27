import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { DiagnosesHttpService } from "../../http/consulting/diagnoses-http.service";
import { IDiagnosticCodes } from "../../model/consult/IDiagnosis";

@Injectable()
export class DiagnosesListResolver implements Resolve<Observable<IDiagnosticCodes[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IDiagnosticCodes[]> {
    return this.http.schemeList(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: DiagnosesHttpService) { }
}
