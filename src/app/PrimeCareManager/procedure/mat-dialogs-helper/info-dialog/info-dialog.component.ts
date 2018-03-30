import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-info-dialog',
  templateUrl: './info-dialog.component.html',
  styleUrls: ['./info-dialog.component.scss'],
})
export class InfoDialogComponent {

  public name: string;
  public info: string;

  public surgeonName: string;
  public anesthologist: string;

  public crna: string;
  public circleNurse: string;

  constructor(public dialogRef: MatDialogRef<InfoDialogComponent, boolean>) { }

}
