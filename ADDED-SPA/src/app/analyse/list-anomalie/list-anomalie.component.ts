import { Component, OnInit } from '@angular/core';
import { Anomalie } from 'src/app/Models/Anomalie';
import { MatTableDataSource } from '@angular/material';
import { Pagination, PaginatedResult } from 'src/app/Models/Pagination';
import { AnalyseService } from 'src/app/_services/analyse.service';

@Component({
  selector: 'app-list-anomalie',
  templateUrl: './list-anomalie.component.html',
  styleUrls: ['./list-anomalie.component.css']
})
export class ListAnomalieComponent implements OnInit {

  AnomalieParam: any = {};
  Anomalies: Anomalie[];
  ListAnomalie: MatTableDataSource<Anomalie>;
  pagination: Pagination;
  displayedColumns: string[] = ['Tournee', 'Ordre', 'Police', 'Anomalie', 'ID'];
constructor(private anomalieService: AnalyseService) {}
  ngOnInit() {
    this.Reset();
  }
  Reset() {
   this.AnomalieParam.Anomalie = null;
   this.pagination = {
      currentPage: 1,
      itemsPerPage: 5,
      totalItems: null,
      totalPages: null,
    };
   this.loadAnomalie();
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadAnomalie();
  }
  loadAnomalie() {
    this.anomalieService
      .getAnomalielist(
        this.pagination.currentPage,
        this.pagination.itemsPerPage,
        this.AnomalieParam
      )
      .subscribe((res: PaginatedResult<Anomalie[]>) => {
        this.Anomalies = res.result;
        this.ListAnomalie = new MatTableDataSource(this.Anomalies);
        this.pagination = res.pagination;
      });
  }
}
