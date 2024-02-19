import { Component, OnInit } from '@angular/core';
import { Affectation } from '../Models/Affectation';
import { Pagination, PaginatedResult } from '../Models/Pagination';
import { AlertifyService } from '../_services/alertify.service';
import { AffectationService } from '../_services/Affectation.service';
import { LocaliteService } from '../_services/Localite.service';
import { MatTableDataSource, MatDialog, MatDialogConfig } from '@angular/material';
import { ReleveurForAffectation } from '../Models/ReleveurForAffectation';
import { PortableForAffectation } from '../Models/PortableForAffectation';
import { AffectationDialogComponent } from './AffectationDialog/AffectationDialog.component';
import { ConfirmationComponent } from '../confirmation/confirmation.component';

@Component({
  selector: 'app-affectation',
  templateUrl: './Affectation.component.html',
  styleUrls: ['./Affectation.component.css']
})
export class AffectationComponent implements OnInit {
  AffectationParam: any = {};
  Affectations: Affectation[];
  Localites = [];
  pagination: Pagination;
  ListAffectation: MatTableDataSource<Affectation>;
  displayedColumns: string[] = ['Id', 'Releveur', 'Localite', 'Portable', 'Marque', 'Action'];
  constructor(
    private dialog: MatDialog,
    private affectationService: AffectationService,
    private alertify: AlertifyService,
    private localiteService: LocaliteService,
  ) {}
  ngOnInit() {
    this.Reset();
    this.localiteService.getLocalites().subscribe((res) => (this.Localites = res as []));
  }
  Reset() {
    this.AffectationParam.CodLocalite = null;
    this.AffectationParam.Releveur = null;
    this.AffectationParam.Portable = null;
    this.pagination = {
      currentPage: 1,
      itemsPerPage: 5,
      totalItems: null,
      totalPages: null,
    };
    this.loadAffectation();
  }
  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadAffectation();
  }

  loadAffectation() {
    this.affectationService
      .getAffectationlist(
        this.pagination.currentPage,
        this.pagination.itemsPerPage,
        this.AffectationParam
      )
      .subscribe((res: PaginatedResult<Affectation[]>) => {
        this.Affectations = res.result;
        this.ListAffectation = new MatTableDataSource(this.Affectations);
        this.pagination = res.pagination;
      });
  }
  tocreate(row?) {
    let data: any;
    const releveur: ReleveurForAffectation = row ? {
    idReleveur: row.idReleveur,
    tspUsername: row.tspUsername,
    libLocalite: row.libLocalite,
      } : null;
    const portable: PortableForAffectation = row ? {
        idPort: row.idPort,
        marquePort: row.marquePort,
          } : null;
    data = {
        Releveur: releveur,
        Portable: portable,
      };
    return data;
  }
  onCreate(row?: any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = '120%';
    dialogConfig.data = this.tocreate(row);
    const dialogRef = this.dialog.open(AffectationDialogComponent, dialogConfig);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed');
      if (result) {
        if (row) {
          this.affectationService.putAffectation(
            {
              Releveur: null,
              Portable: row.idPort,
            }
          ).subscribe(
            (res: any) => {
            console.log(res);
            });
        }
        this.affectationService.putAffectation(
          {
            Releveur: result.Releveur.idReleveur,
            Portable: result.Portable.idPort,
          }
        ).subscribe(
         (res: any) => {
          this.loadAffectation();
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
       this.affectationService.putAffectation({
        Releveur: null,
        Portable: row.idPort,
      }).subscribe(
         () => {
           this.loadAffectation();
           this.alertify.success('deleted');
         });
      }
    });
  }
}
