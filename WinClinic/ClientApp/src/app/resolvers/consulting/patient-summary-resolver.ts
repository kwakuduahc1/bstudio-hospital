import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { ISummary } from "../../model/consult/ISummary";
import { HttpService } from "../../http/consulting/http.service";

@Injectable()
export class PatientSummaryResolver implements Resolve<Observable<ISummary[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<ISummary[]> {
    return this.http.summary(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: HttpService) { }
}
