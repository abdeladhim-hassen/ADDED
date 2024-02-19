import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
RegisterMod = false;
  constructor() { }

  ngOnInit() {
  }
RegisterToggle() {
  this.RegisterMod = true;
}
cancelRegisterMode(registermod: boolean) {
  this.RegisterMod = registermod;
}
}
