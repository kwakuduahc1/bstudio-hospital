import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IPatients } from "../../model/IPatients";
import { HttpService } from "../../http/consulting/http.service";

@Injectable()
export class FindPatientResolver implements Resolve<Observable<IPatients>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatients> {
    return this.http.find(route.paramMap.get('id') as string);
  }

  constructor(private http: HttpService) { }
}
