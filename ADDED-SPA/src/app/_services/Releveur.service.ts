import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../Models/Pagination';
import { HttpParams, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Releveur } from '../Models/Releveur';

@Injectable({
    providedIn: 'root'
  })
  export class ReleveurService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  getReleveurlist(page?, itemsPerPage?, ReleveurParam?): Observable<PaginatedResult<Releveur[]>> {
    const paginatedResult: PaginatedResult<Releveur[]> = new PaginatedResult<Releveur[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null ) {
    params = params.append('PageNumber', page);
    params = params.append('pageSize', itemsPerPage);
    }
    if (ReleveurParam.Releveur != null) {
      params = params.append('Releveur', ReleveurParam.Releveur); }
    if (ReleveurParam.CodLocalite != null) {
      params = params.append('CodLocalite', ReleveurParam.CodLocalite); }
    return this.http.get<Releveur[]>(this.baseUrl + 'releveur', { observe: 'response', params})
    .pipe(
      map(response => {
        paginatedResult.result = response.body;
        if (response.headers.get('Pagination') != null) {
          paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
        }
        return paginatedResult;
      })
    );
  }
  postReleveur(formData: any) {
    return this.http.post(this.baseUrl + 'releveur', formData);
  }
  putReleveur(formData: any) {
    return this.http.put(this.baseUrl + 'releveur', formData);
  }
  deleteReleveur(id: number) {
    return this.http.delete(this.baseUrl + 'releveur/' + id);
  }
  }
