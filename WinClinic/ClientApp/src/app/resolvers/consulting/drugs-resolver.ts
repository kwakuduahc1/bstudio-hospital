import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IDrugs } from "../../model/consult/IDrugs";
import { HttpService } from "../../http/consulting/http.service";

@Injectable()
export class DrugsResolver implements Resolve<Observable<IDrugs[]>> {
  resolve(route:ActivatedRouteSnapshot): Observable<IDrugs[]> {
    return this.http.drugs(route.parent.paramMap.get('id' as string));
  }

  constructor(private http: HttpService) { }
}
