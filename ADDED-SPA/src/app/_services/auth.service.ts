import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
export class AuthService {
baseUrl = environment.apiUrl + 'auth/';
jwtHelper = new JwtHelperService();
decodedtoken: any;
constructor(private http: HttpClient) {}
  login(model: any) {
    return this.http.post(this.baseUrl + 'login', model).pipe(map((response: any ) => {
      const chef = response;
      if (chef) {localStorage.setItem('token', chef.token);
                 this.decodedtoken = this.jwtHelper.decodeToken(chef.token);
    }
    }));
  }
Register(model: any) {
  return this.http.post(this.baseUrl + 'register' , model);
}
loggedin() {
  const token = localStorage.getItem('token');
  return !this.jwtHelper.isTokenExpired(token);
}
}
