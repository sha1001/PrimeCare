import { Injectable } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material';
import { Observable } from 'rxjs/Observable';
import { InfoDialogComponent } from './info-dialog/info-dialog.component';
import { map } from 'rxjs/operators/map';

@Injectable()
export class MatDialogsHelperService {
  public defaultWidth = '30vw';

  constructor(private dialogs: MatDialog) {}

  public confirm(title, message): Observable<boolean> {
    let dialogRef: MatDialogRef<InfoDialogComponent>;

    dialogRef = this.dialogs.open(InfoDialogComponent, { width: this.defaultWidth });

    dialogRef.componentInstance.title = title;
    dialogRef.componentInstance.message = message;

    return dialogRef.afterClosed().pipe(map((res) => !!res)); // always return a boolean value
  }
}
