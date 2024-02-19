import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { PortableForAffectation } from 'src/app/Models/PortableForAffectation';
import { MatTableDataSource } from '@angular/material';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AffectationService } from 'src/app/_services/Affectation.service';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-portablelist',
  templateUrl: './PortableList.component.html',
  styleUrls: ['./PortableList.component.css']
})
export class PortableListComponent implements OnInit {

  @Output() saveEmitter = new EventEmitter();
  @Input() DefaultValue: PortableForAffectation;
  Portables: PortableForAffectation[];
  displayedColumns: string[] = ['select', 'No', 'Portable'];
  ListPortable = new MatTableDataSource<PortableForAffectation>(this.Portables);
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
    this.selection = new SelectionModel<PortableForAffectation>(false, this.DefaultValue ? [this.DefaultValue] : [] );
    this.loadPortables();
  }

  loadPortables() {
    this.affectationService.getPortables().subscribe((Portable) => {
      this.Portables = Portable;
      if  (this.DefaultValue) {this.Portables = this.Portables.concat( [this.DefaultValue]); }
      this.ListPortable = new MatTableDataSource(this.Portables);
      }, error => {
       this.alertify.error(error);
    });
    }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.ListPortable.filter = filterValue.trim().toLowerCase();
  }
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.ListPortable.data.length;
    return numSelected === numRows;
  }
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.ListPortable.data.forEach(row => this.selection.select(row));
  }
  checkboxLabel(row?: PortableForAffectation): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.idPort + 1}`;
  }


}
