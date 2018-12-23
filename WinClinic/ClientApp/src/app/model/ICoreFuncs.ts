import { IHttpMethods } from "./IHttpMethods";
import { HttpErrorResponse } from "@angular/common/http";

export interface ICoreFuncs<T> {
  add(item: T): void;
  delete(item: T): void;
  edit(item: T): void;
  search(qry: string): void;
  list: T[];
  http: IHttpMethods<T>;
  message: string;
  isProcessing: boolean;
  isError: boolean;
  isDismissed: boolean;
  beginProc(): void;
  endProc(): void;
  onAdded(item: T): void;
  onDeleted(item: T): void;
  onEdited(item: T): void;
  onError(err: HttpErrorResponse): void;
}
