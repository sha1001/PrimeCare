import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { InfoDialogComponent } from './info-dialog/info-dialog.component';
import { map } from 'rxjs/operators/map';
import { Patient } from '../../../view-models/patientinfo';

@Injectable()
export class MatDialogsHelperService {
  public defaultWidth = '100vw';

  constructor(private dialogs: MatDialog) {}

  public confirm(message): Observable<boolean> {
    let dialogRef: MatDialogRef<InfoDialogComponent>;
    const patient = <Patient>message;


    dialogRef = this.dialogs.open(InfoDialogComponent, { panelClass :  'my-full-screen-dialog' } );

    dialogRef.componentInstance.name = patient.Name;
    dialogRef.componentInstance.info = patient.Info;
    dialogRef.componentInstance.anesthologist = patient.Anesthologist;
    dialogRef.componentInstance.circleNurse = patient.CircleNurse;
    dialogRef.componentInstance.crna = patient.Crna;
    dialogRef.componentInstance.surgeonName = patient.SurgeonName;

    return dialogRef.afterClosed().pipe(map((res) => !!res)); // always return a boolean value
  }
}
