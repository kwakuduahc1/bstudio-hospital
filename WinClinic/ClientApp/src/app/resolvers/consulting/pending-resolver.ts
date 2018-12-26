import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import { IPending } from "../../model/consult/IPending";
import { HttpService } from "../../http/consulting/http.service";

@Injectable()
export class PendingResolver implements Resolve<Observable<IPending[]>> {
    resolve(route: ActivatedRouteSnapshot): Observable<IPending[]> {
        return this.http.list();
    }

    constructor(private http: HttpService) { }
}
