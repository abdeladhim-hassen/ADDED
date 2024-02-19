import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { PlanningComponent } from './Planning/Planning.component';
import { ReleveComponent } from './Releve/Releve.component';
import { ReleveurComponent } from './Releveur/Releveur.component';
import { AffectationComponent } from './Affectation/Affectation.component';
import { PortableComponent } from './Portable/Portable.component';
import { AnalyseComponent } from './analyse/analyse.component';
export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children : [
    { path: 'Planning', component: PlanningComponent },
    { path: 'Releve', component: ReleveComponent },
    { path: 'Releveur', component: ReleveurComponent },
    { path: 'Affectation', component: AffectationComponent },
    { path: 'Portable', component: PortableComponent },
    { path: 'Analyse', component: AnalyseComponent },
    { path: '**', redirectTo: 'Planning', pathMatch: 'full' }
  ]
  },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
