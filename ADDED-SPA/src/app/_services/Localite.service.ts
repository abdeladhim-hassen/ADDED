import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LocaliteService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getLocalites() {
    return this.http.get(this.baseUrl + 'localite');
  }

}
