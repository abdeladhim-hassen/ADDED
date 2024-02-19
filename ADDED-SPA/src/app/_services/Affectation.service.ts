import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../Models/Pagination';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Affectation } from '../Models/Affectation';
import { map } from 'rxjs/operators';
import { ReleveurForAffectation } from '../Models/ReleveurForAffectation';
import { PortableForAffectation } from '../Models/PortableForAffectation';

@Injectable({
  providedIn: 'root'
})
export class AffectationService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }
  getAffectationlist(page?, itemsPerPage?, AffectationParam?): Observable<PaginatedResult<Affectation[]>> {
    const paginatedResult: PaginatedResult<Affectation[]> = new PaginatedResult<Affectation[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null ) {
    params = params.append('PageNumber', page);
    params = params.append('pageSize', itemsPerPage);
    }
    if (AffectationParam.Releveur != null) {
      params = params.append('Releveur', AffectationParam.Releveur); }
    if (AffectationParam.CodLocalite != null) {
      params = params.append('codLocalite', AffectationParam.CodLocalite); }
    if (AffectationParam.Portable != null) {
        params = params.append('Portable', AffectationParam.Portable); }
    return this.http.get<Affectation[]>(this.baseUrl + 'affectation', { observe: 'response', params})
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
  putAffectation(formData: any) {
    return this.http.put(this.baseUrl + 'affectation', formData);
  }

  getReleveurs(): Observable<ReleveurForAffectation[]> {
    return this.http.get<ReleveurForAffectation[]>(this.baseUrl + 'affectation/releveur');
  }
  getPortables(): Observable<PortableForAffectation[]> {
    return this.http.get<PortableForAffectation[]>(this.baseUrl + 'affectation/portable');
  }
}
