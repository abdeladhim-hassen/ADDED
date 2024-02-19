import { Component, OnInit, Inject} from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';


@Component({
  selector: 'app-planningdialog',
  templateUrl: './PlanningDialog.component.html',
  styleUrls: ['./PlanningDialog.component.css']
})
export class PlanningDialogComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<PlanningDialogComponent>,
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
    SaveTournee(event) {
      this.data.Tournee = Object.assign([], event);
    }
}
