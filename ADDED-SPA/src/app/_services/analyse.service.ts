import { Injectable } from '@angular/core';
import { Anomalie } from '../Models/Anomalie';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../Models/Pagination';
import { map } from 'rxjs/operators';
import { Index } from '../Models/Index';
import { Compteur } from '../Models/Compteur';

@Injectable({
  providedIn: 'root'
})
export class AnalyseService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }




  getIndexist(page?, itemsPerPage?, IndexParam?): Observable<PaginatedResult<Index[]>> {
    const paginatedResult: PaginatedResult<Index[]> = new PaginatedResult<Index[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null ) {
    params = params.append('PageNumber', page);
    params = params.append('pageSize', itemsPerPage);
    }
    if (IndexParam.Ordre != null) {
      params = params.append('Ordre', IndexParam.Ordre); }
    if (IndexParam.Tournee != null) {
        params = params.append('Tournee', IndexParam.Tournee); }

    return this.http.get<Index[]>(this.baseUrl + 'analyse/index', { observe: 'response', params})
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





getAnomalielist(page?, itemsPerPage?, AnomalieParam?): Observable<PaginatedResult<Anomalie[]>> {
  const paginatedResult: PaginatedResult<Anomalie[]> = new PaginatedResult<Anomalie[]>();
  let params = new HttpParams();
  if (page != null && itemsPerPage != null ) {
  params = params.append('PageNumber', page);
  params = params.append('pageSize', itemsPerPage);
  }
  if (AnomalieParam.Anomalie != null) {
    params = params.append('Anomalie', AnomalieParam.Anomalie); }
  return this.http.get<Anomalie[]>(this.baseUrl + 'analyse/anomalie', { observe: 'response', params})
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

getCompteurlist(page?, itemsPerPage?, CompteurParam?): Observable<PaginatedResult<Compteur[]>> {
  const paginatedResult: PaginatedResult<Compteur[]> = new PaginatedResult<Compteur[]>();
  let params = new HttpParams();
  if (page != null && itemsPerPage != null ) {
  params = params.append('PageNumber', page);
  params = params.append('pageSize', itemsPerPage);
  }
  if (CompteurParam.Compteur != null) {
    params = params.append('Compteur', CompteurParam.Compteur); }
  if (CompteurParam.Tournee != null) {
      params = params.append('Tournee', CompteurParam.Tournee); }
  return this.http.get<Compteur[]>(this.baseUrl + 'analyse/compteur', { observe: 'response', params})
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
