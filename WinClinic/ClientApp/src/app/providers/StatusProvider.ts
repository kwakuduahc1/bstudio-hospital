import { Injectable } from "@angular/core";
import { IStaff } from "../model/IStaff";

@Injectable()
export class StatusProvider {
  isLoggedIn: boolean = false;
  user: IStaff | undefined;
  constructor() {
  }
}
