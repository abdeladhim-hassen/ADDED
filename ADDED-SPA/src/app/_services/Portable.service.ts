import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Portable } from '../Models/Portable';
import { PaginatedResult } from '../Models/Pagination';
import { HttpParams, HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
  })
  export class PortableService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  getPortablelist(page?, itemsPerPage?, PortableParam?): Observable<PaginatedResult<Portable[]>> {
    const paginatedResult: PaginatedResult<Portable[]> = new PaginatedResult<Portable[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null ) {
    params = params.append('PageNumber', page);
    params = params.append('pageSize', itemsPerPage);
    }
    if (PortableParam.Portable != null) {
      params = params.append('Portable', PortableParam.Portable);
    }
    if (PortableParam.Etat != null) {
      params = params.append('Etat', PortableParam.Etat);
    }
    return this.http.get<Portable[]>(this.baseUrl + 'portable', { observe: 'response', params})
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
  postPortable(formData: any) {
    return this.http.post(this.baseUrl + 'portable', formData);
  }
  putPortable(formData: any) {
    return this.http.put(this.baseUrl + 'portable', formData);
  }
  deletePortable(id: number) {
    return this.http.delete(this.baseUrl + 'portable/' + id);
  }
  }
