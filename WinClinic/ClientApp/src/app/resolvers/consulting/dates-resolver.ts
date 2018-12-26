import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { SummarytHttpService } from "../../http/consulting/summary-http.service";
import { IVisitDate } from "../../model/consult/IVisitDates";

@Injectable()
export class DatesResolver implements Resolve<Observable<IVisitDate[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IVisitDate[]> {
    return this.http.date(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: SummarytHttpService) { }
}
