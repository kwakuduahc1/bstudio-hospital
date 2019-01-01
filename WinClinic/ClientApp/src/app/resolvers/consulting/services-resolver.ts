import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IServiceCodes } from "../../model/consult/IServices";
import { HttpService } from "../../http/consulting/http.service";

@Injectable()
export class ServicesResolver implements Resolve<Observable<IServiceCodes[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IServiceCodes[]> {
    return this.http.services(route.parent.paramMap.get('id' as string));
  }

  constructor(private http: HttpService) { }
}
