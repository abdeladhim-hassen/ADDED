import { Component, OnInit, ViewChild, AfterViewInit, Output, EventEmitter, OnDestroy, Input } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { Tournee } from 'src/app/Models/Tournee';
import { MatTableDataSource } from '@angular/material';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { PlanningService } from 'src/app/_services/Planning.service';

@Component({
  selector: 'app-listtournee',
  templateUrl: './ListTournee.component.html',
  styleUrls: ['./ListTournee.component.css']
})
export class ListTourneeComponent implements OnInit {
  @Output() saveEmitter = new EventEmitter();
  @Input() DefaultValue: Tournee[];
  Tournees: Tournee[];
  displayedColumns: string[] = ['select', 'No', 'Tournee'];
  ListTournee = new MatTableDataSource<Tournee>(this.Tournees);
  selection: any;
  iscompleted = false;
  constructor(
    private alertify: AlertifyService,
    private planningService: PlanningService
  ) { }
  send(): void {
    this.iscompleted = this.selection.selected.length > 0;
    this.saveEmitter.emit(this.selection.selected);
  }
  ngOnInit() {
   this.selection = new SelectionModel<Tournee>(true, this.DefaultValue);
   this.loadTournees();
  }
  loadTournees() {
    this.planningService.getTournee().subscribe((tournee) => {
      this.Tournees = tournee;
      if  (this.DefaultValue) {this.Tournees = this.Tournees.concat( this.DefaultValue); }
      this.ListTournee = new MatTableDataSource(this.Tournees);
      }, error => {
       this.alertify.error(error);
    });
    }
 applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.ListTournee.filter = filterValue.trim().toLowerCase();
  }
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.ListTournee.data.length;
    return numSelected === numRows;
  }
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.ListTournee.data.forEach(row => this.selection.select(row));
  }
  checkboxLabel(row?: Tournee): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.idTour + 1}`;
  }
}
