import { Injectable } from "@angular/core";
import { Resolve } from "@angular/router";
import { Observable } from "rxjs";
import { ILabGroups } from "../../model/consult/ILabGroups";
import { HttpService } from "../../http/consulting/http.service";

@Injectable()
export class LabsResolver implements Resolve<Observable<ILabGroups[]>> {
  resolve(): Observable<ILabGroups[]> {
    return this.http.labGroups();
  }

  constructor(private http: HttpService) { }
}
