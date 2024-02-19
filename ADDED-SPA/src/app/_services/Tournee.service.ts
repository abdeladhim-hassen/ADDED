import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../Models/Pagination';
import { map } from 'rxjs/operators';
import { Tournee } from '../Models/Tournee';

@Injectable({
  providedIn: 'root'
})
export class TourneeService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  getTourneelist(page?, itemsPerPage?, TourneeParam?): Observable<PaginatedResult<Tournee[]>> {
    const paginatedResult: PaginatedResult<Tournee[]> = new PaginatedResult<Tournee[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null ) {
    params = params.append('PageNumber', page);
    params = params.append('pageSize', itemsPerPage);
    }
    if (TourneeParam.Tour != null) {
      params = params.append('Tour', TourneeParam.Tour);
    }
    return this.http.get<Tournee[]>(this.baseUrl + 'tournee', { observe: 'response', params})
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
}
