import { Component, OnInit } from '@angular/core';
import { Compteur } from 'src/app/Models/Compteur';
import { MatTableDataSource } from '@angular/material';
import { Pagination, PaginatedResult } from 'src/app/Models/Pagination';
import { AnalyseService } from 'src/app/_services/analyse.service';

@Component({
  selector: 'app-list-compteur',
  templateUrl: './list-compteur.component.html',
  styleUrls: ['./list-compteur.component.css']
})
export class ListCompteurComponent implements OnInit {
  CompteurParam: any = {};
  Compteurs: Compteur[];
  ListCompteur: MatTableDataSource<Compteur>;
  pagination: Pagination;
  displayedColumns: string[] = ['Tournee', 'Anomalie', 'ID', 'Ordre', 'Index', 'Numero', 'Adresse'];
constructor(private anomalieService: AnalyseService) {}
  ngOnInit() {
    this.Reset();
  }
  Reset() {
   this.CompteurParam.Tournee = null;
   this.CompteurParam.Compteur = null;
   this.pagination = {
      currentPage: 1,
      itemsPerPage: 5,
      totalItems: null,
      totalPages: null,
    };
   this.loadCompteur();
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadCompteur();
  }
  loadCompteur() {
    this.anomalieService
      .getCompteurlist(
        this.pagination.currentPage,
        this.pagination.itemsPerPage,
        this.CompteurParam
      )
      .subscribe((res: PaginatedResult<Compteur[]>) => {
        this.Compteurs = res.result;
        this.ListCompteur = new MatTableDataSource(this.Compteurs);
        this.pagination = res.pagination;
      });
  }

}
