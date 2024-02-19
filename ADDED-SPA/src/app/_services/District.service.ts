import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class DistrictService {

  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getDistricts() {
    return this.http.get(this.baseUrl + 'district');
  }
}
