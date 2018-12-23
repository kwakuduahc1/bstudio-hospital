import { CanActivate, Router, ActivatedRouteSnapshot, ActivatedRoute } from "@angular/router";
import { Injectable } from "@angular/core";
import { StatusProvider } from "../providers/StatusProvider";

@Injectable()
export class LoginGuard implements CanActivate {
  canActivate(route: ActivatedRouteSnapshot): boolean {
    if (this.status.isLoggedIn)
      return true;
    else
      this.router.navigate(['/login']);
    return false;
  }

  constructor(private router: Router, private status: StatusProvider) {

  }
}
