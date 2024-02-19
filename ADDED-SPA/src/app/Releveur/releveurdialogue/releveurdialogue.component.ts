import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { LocaliteService } from 'src/app/_services/Localite.service';

@Component({
  selector: 'app-releveurdialogue',
  templateUrl: './releveurdialogue.component.html',
  styleUrls: ['./releveurdialogue.component.css']
})
export class ReleveurdialogueComponent implements OnInit {
  hide = true;
  copy: any;
  Localites = [];
  constructor(
    public dialogRef: MatDialogRef<ReleveurdialogueComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private localiteService: LocaliteService) {
    }
  ngOnInit() {
    this.localiteService
      .getLocalites()
      .subscribe((res) => (this.Localites = res as []));
    this.copy = {
      codLocalite: this.data.codLocalite,
      username: this.data.tspUsername,
      password: this.data.tspPassword,
      Localite: this.data.libLocalite
    };
  }
  onChange(value) {
    const index = this.Localites.findIndex(d => d.codLocalite === value);
    this.data.libLocalite = this.Localites[index].libLocalite;
  }
cancel() {
  this.data.codLocalite = this.copy.codLocalite;
  this.data.tspUsername = this.copy.username;
  this.data.tspPassword = this.copy.password;
  this.data.libLocalite = this.copy.Localite;
  this.dialogRef.close();
}

}
