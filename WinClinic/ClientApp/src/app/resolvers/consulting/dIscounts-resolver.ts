import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IPatientDiscounts } from "../../model/consult/IDiscounts";
import { DiscountsHttpService } from "../../http/consulting/discounts-http.service";

@Injectable()
export class DiscountsResolver implements Resolve<Observable<IPatientDiscounts[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatientDiscounts[]> {
    return this.http.list(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: DiscountsHttpService) { }
}
