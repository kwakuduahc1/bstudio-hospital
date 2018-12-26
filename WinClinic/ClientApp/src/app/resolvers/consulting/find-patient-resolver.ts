import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { HttpService } from "../../http/consulting/http.service";
import { IPatients } from "../../model/IPatients";

@Injectable()
export class FindParentPatientResolver implements Resolve<Observable<IPatients>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatients> {
    return this.http.find(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: HttpService) { }
}
