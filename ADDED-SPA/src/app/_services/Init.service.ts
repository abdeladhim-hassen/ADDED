import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InitService {
baseUrl = environment.apiUrl;
constructor(private http: HttpClient) { }
verifier(model: any) {
  return this.http.post(this.baseUrl + 'inisialisation/verifier', model);
}
import(model: any) {
  return this.http.post(this.baseUrl + 'inisialisation/importer', model);
}
getinfo() {
  return this.http.get(this.baseUrl + 'inisialisation/information');
}
}
