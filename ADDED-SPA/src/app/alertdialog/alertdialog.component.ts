import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-alertdialog',
  templateUrl: './alertdialog.component.html',
  styleUrls: ['./alertdialog.component.css']
})
export class AlertdialogComponent implements OnInit {

  message = '';
  cancelButtonText = 'Cancel';
  constructor(
    @Inject(MAT_DIALOG_DATA) private data: any,
    private dialogRef: MatDialogRef<AlertdialogComponent>) {
    if (data) {
      this.message = data.message || this.message;
      if (data.buttonText) {
        this.cancelButtonText = data.buttonText.cancel || this.cancelButtonText;
      }
    }
    this.dialogRef.updateSize('300vw', '300vw');
  }
  ngOnInit() {
  }

  onConfirmClick(): void {
    this.dialogRef.close(true);
  }

}
