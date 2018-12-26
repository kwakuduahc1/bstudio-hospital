import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IConsultation } from "../../model/consult/IConsult";
import { ConsultHttpService } from "../../http/consulting/consult-http.service";

@Injectable()
export class HistoryResolver implements Resolve<Observable<IConsultation[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IConsultation[]> {
    return this.http.list(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: ConsultHttpService) { }
}
