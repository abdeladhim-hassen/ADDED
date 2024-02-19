import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Planning } from '../Models/Planning';
import { Observable } from 'rxjs';
import { PaginatedResult } from '../Models/Pagination';
import { map } from 'rxjs/operators';
import { Affectation } from '../Models/Affectation';
import { ReleveurForPlanning } from '../Models/ReleveurForPlanning';
import { Tournee } from '../Models/Tournee';

@Injectable({
  providedIn: 'root'
})
export class PlanningService {
  listReleveur = [];

  baseUrl = environment.apiUrl;



  constructor(private http: HttpClient) { }
 getPlanninglist(page?, itemsPerPage?, PlanningParam?): Observable<PaginatedResult<Planning[]>> {
    const paginatedResult: PaginatedResult<Planning[]> = new PaginatedResult<Planning[]>();
    let params = new HttpParams();
    if (page != null && itemsPerPage != null ) {
    params = params.append('PageNumber', page);
    params = params.append('pageSize', itemsPerPage);
    }
    if (PlanningParam.Releveur != null) {
      params = params.append('Releveur', PlanningParam.Releveur); }
    if (PlanningParam.Portable != null) {
        params = params.append('Portable', PlanningParam.Portable); }
    if (PlanningParam.Tour != null) {
         params = params.append('tour', PlanningParam.Tour); }
    return this.http.get<Planning[]>(this.baseUrl + 'planning', { observe: 'response', params})
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




   getTournee(): Observable<Tournee[]> {
    return this.http.get<Tournee[]>(this.baseUrl + 'planning/tournee');
  }






  getReleveurs(): Observable<ReleveurForPlanning[]> {
    return this.http.get<ReleveurForPlanning[]>(this.baseUrl + 'planning/releveur');
  }





  putPlanning(formData: any) {
    return this.http.put(this.baseUrl + 'planning', formData);
  }
}
