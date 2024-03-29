import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  constructor(public authservice: AuthService, private alertify: AlertifyService, private router: Router) {}
  model: any = {};
  ngOnInit() {}
  Login() {
    this.authservice.login(this.model).subscribe(
      next => {
        this.alertify.success('Logged in successfully');
      },
      error => {
        this.alertify.error(error);
      },
      () => {
        this.router.navigate(['/Planning']);
      }
    );
  }
  Logedin() {
    return this.authservice.loggedin();
  }
  Logout() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
  }
}
