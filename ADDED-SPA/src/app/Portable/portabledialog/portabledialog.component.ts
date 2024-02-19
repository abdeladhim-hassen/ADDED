import { Component, OnInit, Inject } from '@angular/core';
import { PortableService } from 'src/app/_services/Portable.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-portabledialog',
  templateUrl: './portabledialog.component.html',
  styleUrls: ['./portabledialog.component.css']
})
export class PortabledialogComponent implements OnInit {
  copy: any;
  constructor(
              public dialogRef: MatDialogRef<PortabledialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: any) {
              }
  ngOnInit() {
    this.copy = {
      marque: this.data.marquePort,
      etat: this.data.etatPort,
    };
  }

  setValue(e) {
    if (e.checked) {
      this.data.etatPort = 1;
   } else {
    this.data.etatPort = 0;
   }
  }
cancel() {
  this.data.marquePort = this.copy.marque;
  this.data.etatPort = this.copy.etat;
  this.dialogRef.close();
}
}
