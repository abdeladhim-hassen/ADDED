import { Component, OnInit } from '@angular/core';
import { Releveur } from '../Models/Releveur';
import { Pagination, PaginatedResult } from '../Models/Pagination';
import { ReleveurService } from '../_services/Releveur.service';
import { AlertifyService } from '../_services/alertify.service';
import { LocaliteService } from '../_services/Localite.service';
import { MatTableDataSource, MatDialogConfig, MatDialog } from '@angular/material';
import { ReleveurdialogueComponent } from './releveurdialogue/releveurdialogue.component';
import { AlertdialogComponent } from '../alertdialog/alertdialog.component';
import { ConfirmationComponent } from '../confirmation/confirmation.component';

@Component({
  selector: 'app-releveur',
  templateUrl: './Releveur.component.html',
  styleUrls: ['./Releveur.component.css'],
})
export class ReleveurComponent implements OnInit {
  ReleveurParam: any = {};
  Localites = [];
  Releveurs: Releveur[];
  ListReleveur: MatTableDataSource<Releveur>;
  pagination: Pagination;
  displayedColumns: string[] = ['Releveur', 'Localite', 'Username', 'Password', 'Action'];
constructor(private releveurService: ReleveurService,
            private alertify: AlertifyService, private dialog: MatDialog,
            private localiteService: LocaliteService) {
}
  ngOnInit() {
    this.Reset();
    this.localiteService
      .getLocalites()
      .subscribe((res) => (this.Localites = res as []));
  }
  Reset() {
    this.ReleveurParam.CodLocalite = null;
    this.ReleveurParam.Releveur = null;
    this.pagination = {
      currentPage: 1,
      itemsPerPage: 5,
      totalItems: null,
      totalPages: null,
    };
    this.loadReleveur();
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadReleveur();
  }
  loadReleveur() {
    this.releveurService
      .getReleveurlist(
        this.pagination.currentPage,
        this.pagination.itemsPerPage,
        this.ReleveurParam
      )
      .subscribe((res: PaginatedResult<Releveur[]>) => {
        this.Releveurs = res.result;
        this.ListReleveur = new MatTableDataSource(this.Releveurs);
        this.pagination = res.pagination;
      });
  }
  onCreate(row?: any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '60%';
    if (row) {
     dialogConfig.data = row;
     const dialogRef = this.dialog.open(ReleveurdialogueComponent, dialogConfig);
     dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result) {
       this.releveurService.putReleveur(result).subscribe(
         (res: any) => {
           this.alertify.message('update');
         });
      }

    });
   } else {
     dialogConfig.data = {
      codLocalite: null,
      libLocalite: null,
      tspUsername: null,
      tspPassword: null,
        };
     const dialogRef = this.dialog.open(ReleveurdialogueComponent, dialogConfig);
     dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result) {
        this.releveurService.postReleveur(result).subscribe(
        (res: any) => {
          res.libLocalite = result.libLocalite;
          this.Releveurs.push(res);
          this.ListReleveur = new MatTableDataSource(this.Releveurs);
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
         this.releveurService.deleteReleveur(row.idReleveur).subscribe(
           res => {
             this.loadReleveur();
             this.alertify.warning('delete');
           });
       }
     });
   }
   openAlertDialog(row) {
     const dialogRef = this.dialog.open(AlertdialogComponent, {
      data: {
        message: row.tspPassword,
        buttonText: {
          cancel: 'Close'
        }
      },
    });
  }
}
