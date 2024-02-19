import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-affectationdialog',
  templateUrl: './AffectationDialog.component.html',
  styleUrls: ['./AffectationDialog.component.css']
})
export class AffectationDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<AffectationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
  ) { }

  ngOnInit() {
  }
  cancel() {
     this.dialogRef.close();
    }
    SaveReleveur(event) {
      this.data.Releveur = Object.assign({}, event);
    }
    SavePortable(event) {
      this.data.Portable = Object.assign([], event);
    }
}
