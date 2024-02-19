import { Component, OnInit } from '@angular/core';
import { Index } from 'src/app/Models/Index';
import { MatTableDataSource } from '@angular/material';
import { Pagination, PaginatedResult } from 'src/app/Models/Pagination';
import { AnalyseService } from 'src/app/_services/analyse.service';

@Component({
  selector: 'app-list-index',
  templateUrl: './list-index.component.html',
  styleUrls: ['./list-index.component.css']
})
export class ListIndexComponent implements OnInit {
  IndexParam: any = {};
  indexs: Index[];
  ListIndex: MatTableDataSource<Index>;
  pagination: Pagination;
  displayedColumns: string[] = ['Tournee', 'Ordre', 'Police', 'Nouv', 'Ancien', 'Consomation', 'Date'];
constructor(private anomalieService: AnalyseService) {}
  ngOnInit() {
    this.Reset();
  }
  Reset() {
   this.IndexParam.Ordre = null;
   this.IndexParam.Anomalie = null;
   this.pagination = {
      currentPage: 1,
      itemsPerPage: 5,
      totalItems: null,
      totalPages: null,
    };
   this.loadIndex();
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadIndex();
  }
  loadIndex() {
    this.anomalieService
      .getIndexist(
        this.pagination.currentPage,
        this.pagination.itemsPerPage,
        this.IndexParam
      )
      .subscribe((res: PaginatedResult<Index[]>) => {
        this.indexs = res.result;
        this.ListIndex = new MatTableDataSource(this.indexs);
        this.pagination = res.pagination;
      });
  }
}
