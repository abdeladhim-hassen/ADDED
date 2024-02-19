import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { InitService } from '../_services/Init.service';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-releve',
  templateUrl: './Releve.component.html',
  styleUrls: ['./Releve.component.css']
})
export class ReleveComponent implements OnInit {
  Model: any = {};
  info: any = {};
  constructor(private alertify: AlertifyService,
              private initservice: InitService,
              ) { }

  ngOnInit() {
    this.initservice
      .getinfo()
      .subscribe((res) => (this.info = res as {}));
  }
import() {
this.initservice.import(this.Model).subscribe(
    () => {
      this.alertify.success('import successful');
    },
    (error: any) => {
      this.alertify.error(error);
    }
  );
}

verifier() {
  this.initservice.verifier(this.Model).subscribe(
      () => {
        this.alertify.success('import successful');
      },
      (error: any) => {
        this.alertify.error(error);
      }
    );
  }
}
