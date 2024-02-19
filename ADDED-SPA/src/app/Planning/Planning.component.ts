import { Component, OnInit } from '@angular/core';
import { Planning } from '../Models/Planning';
import { Pagination, PaginatedResult } from '../Models/Pagination';
import { PlanningService } from '../_services/Planning.service';
import { AlertifyService } from '../_services/alertify.service';
import { MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { PlanningDialogComponent } from './PlanningDialog/PlanningDialog.component';
import { ConfirmationComponent } from '../confirmation/confirmation.component';
import { ReleveurForPlanning } from '../Models/ReleveurForPlanning';

@Component({
  selector: 'app-planning',
  templateUrl: './Planning.component.html',
  styleUrls: ['./Planning.component.css']
})
export class PlanningComponent implements OnInit {
  PlanningParam: any = {};
  Plannings: Planning[];
  pagination: Pagination;
  PortableParam: any = {};
  ListPlanning: MatTableDataSource<Planning>;
  displayedColumns: string[] = ['Id', 'Releveur', 'Localite', 'IdP', 'Marque', 'Tournee', 'Date', 'Action'];

  constructor(private dialog: MatDialog,
              private planningService: PlanningService,
              private alertify: AlertifyService ) { }

  ngOnInit() {
    this.Reset();
  }
  Reset() {
    this.PlanningParam.Releveur = null;
    this.PlanningParam.Portable = null;
    this.PlanningParam.Tour = null;
    this.PlanningParam.DatAffect  = null;
    this.pagination = {
      currentPage: 1,
      itemsPerPage: 5,
      totalItems: null,
      totalPages: null,
    };
    this.loadPlanning();
  }
  pageChanged(event: any) {
    this.pagination.currentPage = event.page;
    this.loadPlanning();
  }
  loadPlanning() {
    this.planningService
      .getPlanninglist(
        this.pagination.currentPage,
        this.pagination.itemsPerPage,
        this.PlanningParam
      )
      .subscribe((res: PaginatedResult<Planning[]>) => {
        this.Plannings = res.result;
        this.ListPlanning = new MatTableDataSource(this.Plannings);
        this.pagination = res.pagination;
      });
  }
  tocreate(row?) {
    let data: any;
    const releveur: ReleveurForPlanning = row ? {
    idReleveur: row.idReleveur,
    tspUsername: row.tspUsername,
    idPort: row.idPort,
    marquePort: row.marquePort,
      } : null;
    data = {
        Releveur: releveur,
        Tournee: row ? row.tournee : null ,
      };
    return data;
  }
  onCreate(row?: any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '120%';
    const deletedRow = this.tocreate(row);
    dialogConfig.data = Object.assign({}, deletedRow);
    const dialogRef = this.dialog.open(PlanningDialogComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result) {
        if (row) {
          deletedRow.Releveur = null;
          this.planningService.putPlanning(deletedRow).subscribe(
            (res: any) => {
            console.log(res);
            });
        }
        this.planningService.putPlanning(
          {
            Releveur: result.Releveur.idReleveur,
            Tournee: result.Tournee,
          }
        ).subscribe(
         (res: any) => {
          this.loadPlanning();
          this.alertify.message(row == null ? 'insert' : 'update');
         });
      }
    });

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
        const deletedRow = this.tocreate(row);
        deletedRow.Releveur = null;
        this.planningService.putPlanning(deletedRow).subscribe(
          () => {
            this.loadPlanning();
            this.alertify.success('deleted');
          });
       }
     });
   }
}
