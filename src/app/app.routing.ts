
 import { NgModule } from '@angular/core';
 import { Routes, RouterModule } from '@angular/router';
 import { ProcedureComponent } from './PrimeCareManager/procedure/procedure.component';
 import { PatientComponent } from './PrimeCareManager/patient/patient.component';
 import { FacilityresourcesComponent } from './PrimeCareManager/facilityresources/facilityresources.component';
  import { SignInComponent } from './users/sign-in/sign-in.component';
  import { AuthGuard } from './services/auth-guard.service';

 const routes: Routes = [
   { path: 'signin', component: SignInComponent },
   { path: '', pathMatch: 'full', redirectTo: 'procedure' },
   { path: 'procedure', component: ProcedureComponent , canActivate: [AuthGuard] },
   { path: 'patient', component: PatientComponent , canActivate: [AuthGuard] },
   { path: 'facilityresources', component: FacilityresourcesComponent, canActivate: [AuthGuard] },
   { path: '', component: SignInComponent },
   { path: '**', component: SignInComponent }
 ];

 @NgModule({
   imports: [RouterModule.forRoot(routes)],
   exports: [RouterModule],
 })
 export class AppRoutingModule { }
 export const routingComponents = [ProcedureComponent, PatientComponent, FacilityresourcesComponent];
