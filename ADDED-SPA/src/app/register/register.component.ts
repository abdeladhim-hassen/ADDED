import { OnInit, Component, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';
import { DistrictService } from '../_services/District.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  model: any = {};
  districts = [];
  @Output() cancelRegister = new EventEmitter();
  constructor(
    private authservice: AuthService,
    private alertify: AlertifyService,
    private districtService: DistrictService
  ) {}

  ngOnInit() {
    this.districtService.getDistricts().subscribe(res => this.districts = res as []);
  }
  register() {
    this.authservice.Register(this.model).subscribe(
      () => {
        this.alertify.success('registration successful');
      },
      (error) => {
        this.alertify.error(error);
      }
    );
  }
  cancel() {
    this.cancelRegister.emit(false);
    console.log('Cancelled');
  }
}
