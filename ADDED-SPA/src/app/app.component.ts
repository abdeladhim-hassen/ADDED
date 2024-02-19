import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './_services/auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  jwtHelper = new JwtHelperService();
  constructor(private authservice: AuthService) {
  }
  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token) {
      this.authservice.decodedtoken = this.jwtHelper.decodeToken(token);
    }
  }
}
