import { Component, OnInit, EventEmitter, Output, Input, AfterViewInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { ReleveurForPlanning } from 'src/app/Models/ReleveurForPlanning';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { PlanningService } from 'src/app/_services/Planning.service';

@Component({
  selector: 'app-listreleveur',
  templateUrl: './ListReleveur.component.html',
  styleUrls: ['./ListReleveur.component.css']
})
export class ListReleveurComponent implements OnInit {
  @Output() saveEmitter = new EventEmitter();
  @Input() DefaultValue: ReleveurForPlanning;
  Releveurs: ReleveurForPlanning[];
  displayedColumns: string[] = ['select', 'No', 'Releveur', 'Portable', 'Marque'];
  ListReleveur = new MatTableDataSource<ReleveurForPlanning>(this.Releveurs);
  selection: any;
  iscompleted = false;
  constructor(
    private alertify: AlertifyService,
    private planningService: PlanningService
  ) { }

  send() {
    this.iscompleted = this.selection.selected.length > 0;
    this.saveEmitter.emit(this.selection.selected[0]);
  }

  ngOnInit() {
    this.selection = new SelectionModel<ReleveurForPlanning>(false, this.DefaultValue ? [this.DefaultValue] : [] );
    this.loadReleveurs();
  }

  loadReleveurs() {
    this.planningService.getReleveurs().subscribe((Releveur) => {
      this.Releveurs = Releveur;
      if  (this.DefaultValue) {this.Releveurs = this.Releveurs.concat( [this.DefaultValue]); }
      this.ListReleveur = new MatTableDataSource(this.Releveurs);
      }, error => {
       this.alertify.error(error);
    });
    }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.ListReleveur.filter = filterValue.trim().toLowerCase();
  }
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.ListReleveur.data.length;
    return numSelected === numRows;
  }
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.ListReleveur.data.forEach(row => this.selection.select(row));
  }
  checkboxLabel(row?: ReleveurForPlanning): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.idReleveur + 1}`;
  }
}
