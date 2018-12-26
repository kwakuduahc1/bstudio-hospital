import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IServices } from "../../model/consult/IServices";
import { HttpService } from "../../http/consulting/http.service";

@Injectable()
export class ServicesResolver implements Resolve<Observable<IServices[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IServices[]> {
    return this.http.services();
  }

  constructor(private http: HttpService) { }
}
