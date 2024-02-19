import { Portable } from '../Models/Portable';
import { FormBuilder } from '@angular/forms';
import { Pagination, PaginatedResult } from '../Models/Pagination';
import { PortableService } from '../_services/Portable.service';
import { AlertifyService } from '../_services/alertify.service';
import { Component, OnInit } from '@angular/core';
import { MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { PortabledialogComponent } from './portabledialog/portabledialog.component';
import { ConfirmationComponent } from '../confirmation/confirmation.component';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'app-portable',
  templateUrl: './Portable.component.html',
  styleUrls: ['./Portable.component.css']
})
export class PortableComponent implements OnInit {
PortableParam: any = {};
ListPortable: MatTableDataSource<Portable>;
Portables: Portable[];
pagination: Pagination;
displayedColumns: string[] = ['Id', 'Marque', 'Etat', 'Action'];
constructor(private portableService: PortableService,
            private alertify: AlertifyService, private dialog: MatDialog) {
}
ngOnInit() {
  this.Reset();
  }
Reset() {
    this.PortableParam.Portable = null;
    this.PortableParam.Etat = null;
    this.pagination = {
    currentPage : 1,
    itemsPerPage: 3,
    totalItems: null,
    totalPages: null,
    };
    this.loadPortable();
  }
pageChanged(event: any): void {
  this.pagination.currentPage = event.page;
  this.loadPortable();
  }
  setValue(e) {
    if (e.checked) {
      this.PortableParam.Etat = 1;
   } else {
    this.PortableParam.Etat = 0;
   }
  }
loadPortable() {
  this.portableService.getPortablelist( this.pagination.currentPage,
    this.pagination.itemsPerPage,
    this.PortableParam)
  .subscribe((res: PaginatedResult<Portable[]>) => {
    this.Portables = res.result;
    this.ListPortable = new MatTableDataSource(this.Portables);
    this.pagination = res.pagination;
}
);
}

onCreate(row?: any) {
 const dialogConfig = new MatDialogConfig();
 dialogConfig.disableClose = true;
 dialogConfig.autoFocus = true;
 dialogConfig.width = '60%';
 if (row) {
  dialogConfig.data = row;
  const dialogRef = this.dialog.open(PortabledialogComponent, dialogConfig);
  dialogRef.afterClosed().subscribe(result => {
   console.log('The dialog was closed');
   if (result) {
    this.portableService.putPortable(result).subscribe(
      (res: any) => {
        this.alertify.message('update');
      });
   }

 });
} else {
  dialogConfig.data = {
    marquePort: null,
    etatPort: 0,
     };
  const dialogRef = this.dialog.open(PortabledialogComponent, dialogConfig);
  dialogRef.afterClosed().subscribe(result => {
   console.log('The dialog was closed');
   console.log(result);
   if (result) {
   this.portableService.postPortable(result).subscribe(
     (res: any) => {
       this.Portables.push(res);
       this.ListPortable = new MatTableDataSource(this.Portables);
       ++this.pagination.totalItems;
       this.alertify.success('insert');
     }); }
 });

 }
}
openDialog(row) {
  const dialogRef = this.dialog.open(ConfirmationComponent, {
    data: {
      message: 'Are you sure want to delete?',
      buttonText: {
        ok: 'Yes',
        cancel: 'No'
      }
    }
  });

  dialogRef.afterClosed().subscribe((confirmed: boolean) => {
    if (confirmed) {
      this.portableService.deletePortable(row.idPort).subscribe(
        res => {
          this.loadPortable();
          this.alertify.warning('delete');
        });
    }
  });
}
}
