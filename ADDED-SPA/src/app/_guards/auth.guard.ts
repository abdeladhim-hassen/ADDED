import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { AuthService } from '../_services/auth.service';

@Injectable({
    providedIn: 'root'
  })
  export class AuthGuard implements CanActivate {
    constructor(private authservice: AuthService, private router: Router,
                private alertify: AlertifyService) {
    }
    canActivate(): boolean {
      if (this.authservice.loggedin()) {
      return true;
      }
      this.alertify.error('you are not logged in !!!');
      this.router.navigate(['/home']);
      return false;
    }
  }
