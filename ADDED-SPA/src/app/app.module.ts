
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { JwtModule } from '@auth0/angular-jwt';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { appRoutes } from './Routes';
import * as Material from '@angular/material';




import { AuthService } from './_services/auth.service';
import { AlertifyService } from './_services/alertify.service';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { PlanningComponent } from './Planning/Planning.component';
import { ReleveComponent } from './Releve/Releve.component';
import { ReleveurComponent } from './Releveur/Releveur.component';
import { AffectationComponent } from './Affectation/Affectation.component';
import { PortableComponent } from './Portable/Portable.component';
import { PortabledialogComponent } from './Portable/portabledialog/portabledialog.component';
import { ReleveurdialogueComponent } from './Releveur/releveurdialogue/releveurdialogue.component';
import { PlanningDialogComponent } from './Planning/PlanningDialog/PlanningDialog.component';
import { ListTourneeComponent } from './Planning/PlanningDialog/ListTournee/ListTournee.component';
import { ListReleveurComponent } from './Planning/PlanningDialog/ListReleveur/ListReleveur.component';
import { ReleveurListComponent } from './Affectation/AffectationDialog/ReleveurList/ReleveurList.component';
import { AffectationDialogComponent } from './Affectation/AffectationDialog/AffectationDialog.component';
import { PortableListComponent } from './Affectation/AffectationDialog/PortableList/PortableList.component';
import { ConfirmationComponent } from './confirmation/confirmation.component';
import { AlertdialogComponent } from './alertdialog/alertdialog.component';
import { ErrorInterceptorProvider } from './_services/ErrorInterceptor.service';
import { AnalyseComponent } from './analyse/analyse.component';
import { ListIndexComponent } from './analyse/list-index/list-index.component';
import { ListAnomalieComponent } from './analyse/list-anomalie/list-anomalie.component';
import { ListCompteurComponent } from './analyse/list-compteur/list-compteur.component';


/*---------------------------------------------------------*/
/*---------------------------------------------------------*/
export function tokenGetter() {
   return localStorage.getItem('token');
}
@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      PlanningComponent,
      ReleveComponent,
      ReleveurComponent,
      AffectationComponent,
      PortableComponent,
      PlanningDialogComponent,
      PortabledialogComponent,
      ConfirmationComponent,
      AlertdialogComponent,
      ReleveurdialogueComponent,
      ListTourneeComponent,
      ListReleveurComponent,
      ReleveurListComponent,
      PortableListComponent,
      AffectationDialogComponent,
      AnalyseComponent,
      ListIndexComponent,
      ListAnomalieComponent,
      ListCompteurComponent,
   ],
   imports: [
      BrowserAnimationsModule,
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      Material.MatInputModule,
      Material.MatSelectModule,
      Material.MatButtonModule,
      Material.MatCheckboxModule,
      Material.MatTableModule,
      Material.MatIconModule,
      Material.MatDialogModule,
      Material.MatToolbarModule,
      Material.MatGridListModule,
      Material.MatRadioModule,
      Material.MatDatepickerModule,
      Material.MatSnackBarModule,
      Material.MatPaginatorModule,
      Material.MatSortModule,
      Material.MatStepperModule,
      Material.MatListModule,
      Material.MatMenuModule,
      Material.MatSlideToggleModule,
      Material.MatTabsModule,
      RouterModule.forRoot(appRoutes),
      PaginationModule.forRoot(),
      BsDropdownModule.forRoot(),
      JwtModule.forRoot(
         {
            config: {
               tokenGetter,
               whitelistedDomains: ['localhost:5000'],
               blacklistedRoutes: ['localhost:5000/api/auth'],
            }
         }
      )
     ],
   providers: [
      AuthService,
      AlertifyService,
      ErrorInterceptorProvider,

   ],
   bootstrap: [
      AppComponent
   ],
   entryComponents: [
      PortabledialogComponent,
      ConfirmationComponent,
      AlertdialogComponent,
      ReleveurdialogueComponent,
      PlanningDialogComponent,
      AffectationDialogComponent,
   ]
})
export class AppModule { }
