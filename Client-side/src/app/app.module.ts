import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';

import { MaterialModule } from './shared/material.module';
import { SidenavComponent } from './PrimeCareManager/component/sidenav/sidenav.component';
import { ToolbarComponent } from './PrimeCareManager/component/toolbar/toolbar.component';
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { AppRoutingModule, routingComponents } from './app.routing';

import { AppComponent } from './app.component';
import { AppDataService } from './services/app-data.service';
import { PatientDataservice } from './services/patient-dataservice';
import { ProcedureComponent } from './PrimeCareManager/procedure/procedure.component';
import { PatientComponent } from './PrimeCareManager/patient/patient.component';
import { HeaderDataservice } from './services/header-dataservice';

import { FacilityresourcesComponent } from './PrimeCareManager/facilityresources/facilityresources.component';
import { ChartsModule } from 'ng2-charts';

import { SignInComponent } from './users/sign-in/sign-in.component';
import { AuthGuard } from './services/auth-guard.service';
import { UserService } from './services/user.service';
import { UserApi } from './users/user-api';
import { FormsModule } from '@angular/forms';
import { AppHeaderComponent } from './PrimeCareManager/component/app-header/app-header.component';
import { PatFooterComponent } from './PrimeCareManager/component/app-header/app-pat-footer.component';
import { PersonelFooterComponent } from './PrimeCareManager/component/app-header/app-personel-footer.component';
import { ProcFooterComponent } from './PrimeCareManager/component/app-header/app-proc-footer.component';
import { FcFooterComponent } from './PrimeCareManager/component/app-header/app-fc-footer.component';
import { MomentModule } from 'angular2-moment';
import {Globals} from './PrimeCareManager/globals';
import { PersonelComponent } from './PrimeCareManager/personel/personel/personel.component';
import { NotifyComponent } from './PrimeCareManager/notify/notify/notify.component';
import { AnalyticsComponent } from './PrimeCareManager/analytics/analytics/analytics.component';

import { MatDialogsHelperModule } from './PrimeCareManager/procedure/mat-dialogs-helper/mat-dialogs-helper.module';

@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    SidenavComponent,
    ToolbarComponent,
    FacilityresourcesComponent,
    SignInComponent,
    AppHeaderComponent,
    PatFooterComponent,
    PersonelFooterComponent,
    ProcFooterComponent,
    FcFooterComponent,
    PersonelComponent,
    NotifyComponent,
    AnalyticsComponent
  ],
  providers: [
    AppDataService,
    PatientDataservice,
    HeaderDataservice,
    UserService,
    { provide: UserApi, useExisting: UserService },
    AuthGuard,
    Globals
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MaterialModule,
    HttpModule,
    ChartsModule,
    FormsModule,
    MomentModule,
    MatDialogsHelperModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
