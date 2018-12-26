import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IPending } from "../../model/consult/IPending";
import { HttpService } from "../../http/consulting/http.service";

@Injectable()
export class VitalsResolver implements Resolve<Observable<IPending[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPending[]> {
    return this.http.vitals(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: HttpService) { }
}
