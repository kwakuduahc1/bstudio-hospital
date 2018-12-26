import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IPatientFiles } from "../../model/consult/IPatientFiles";
import { FilesHttpService } from "../../http/consulting/files-http.service";

@Injectable()
export class FilesResolver implements Resolve<Observable<IPatientFiles[]>> {
  resolve(route: ActivatedRouteSnapshot): Observable<IPatientFiles[]> {
    return this.http.list(route.parent!.paramMap.get('id') as string);
  }

  constructor(private http: FilesHttpService) { }
}
