import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { ReleveurForAffectation } from 'src/app/Models/ReleveurForAffectation';
import { MatTableDataSource } from '@angular/material';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AffectationService } from 'src/app/_services/Affectation.service';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-releveurlist',
  templateUrl: './ReleveurList.component.html',
  styleUrls: ['./ReleveurList.component.css']
})
export class ReleveurListComponent implements OnInit {

  @Output() saveEmitter = new EventEmitter();
  @Input() DefaultValue: ReleveurForAffectation;
  Releveurs: ReleveurForAffectation[];
  displayedColumns: string[] = ['select', 'No', 'Releveur'];
  ListReleveur = new MatTableDataSource<ReleveurForAffectation>(this.Releveurs);
  selection: any;
  iscompleted = false;
  constructor(
    private alertify: AlertifyService,
    private affectationService: AffectationService,
  ) { }

  send() {
    this.iscompleted = this.selection.selected.length > 0;
    this.saveEmitter.emit(this.selection.selected[0]);
  }

  ngOnInit() {
    this.selection = new SelectionModel<ReleveurForAffectation>(false, this.DefaultValue ? [this.DefaultValue] : [] );
    this.loadReleveurs();
  }

  loadReleveurs() {
    this.affectationService.getReleveurs().subscribe((Releveur) => {
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
  checkboxLabel(row?: ReleveurForAffectation): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.idReleveur + 1}`;
  }

}
