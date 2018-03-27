import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InfoDialogComponent } from './info-dialog/info-dialog.component';
import { MatDialogModule, MatButtonModule } from '@angular/material';
import { MatDialogsHelperService } from './mat-dialogs-helper.service';

@NgModule({
  imports: [
    CommonModule,
    MatDialogModule,
    MatButtonModule
  ],
  declarations: [InfoDialogComponent],
  entryComponents: [InfoDialogComponent],
  providers: [MatDialogsHelperService]
})
export class MatDialogsHelperModule { }
