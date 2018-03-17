

 import { NgModule } from '@angular/core';
 import { Routes, RouterModule } from '@angular/router';
 import { ProcedureComponent } from './PrimeCareManager/procedure/procedure.component';
 import { PatientComponent } from './PrimeCareManager/patient/patient.component';
 import { FacilityresourcesComponent } from './PrimeCareManager/facilityresources/facilityresources.component';
 import { SignInComponent } from './users/sign-in/sign-in.component';
 import { AuthGuard } from './services/auth-guard.service';
 import { PersonelComponent } from './PrimeCareManager/personel/personel/personel.component';
 import { NotifyComponent } from './PrimeCareManager/notify/notify/notify.component';
 import { AnalyticsComponent } from './PrimeCareManager/analytics/analytics/analytics.component';

 const routes: Routes = [
   { path: 'signin', component: SignInComponent },
   { path: '', pathMatch: 'full', redirectTo: 'procedure' },
   { path: 'procedure', component: ProcedureComponent , canActivate: [AuthGuard] },
   { path: 'patient', component: PatientComponent , canActivate: [AuthGuard] },
   { path: 'facilityresources', component: FacilityresourcesComponent, canActivate: [AuthGuard] },
   { path: 'personel', component: PersonelComponent , canActivate: [AuthGuard] },
   { path: 'notify', component: NotifyComponent , canActivate: [AuthGuard] },
   { path: 'analytics', component: AnalyticsComponent , canActivate: [AuthGuard] },
   { path: '', component: SignInComponent },
   { path: '**', component: SignInComponent }
 ];

 @NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule],
 })
 export class AppRoutingModule { }
 export const routingComponents = [ProcedureComponent, PatientComponent,
  FacilityresourcesComponent, PersonelComponent, NotifyComponent, AnalyticsComponent];
