import { findLast } from "@angular/compiler/src/directive_resolver";
import { Observable } from "rxjs";

export interface IHttpMethods<T> {
  add(item: T): Observable<T>;

  edit(item: T): Observable<T>;

  delete(item: T): Observable<T>;

  find(id: string): Observable<T>;

  search(qry: string): Observable<T[]>;

  list(id: string, num?: number): Observable<T[]>;
}
