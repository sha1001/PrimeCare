import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-info-dialog',
  templateUrl: './info-dialog.component.html',
  styleUrls: ['./info-dialog.component.css'],
})
export class InfoDialogComponent {

  public title: string;
  public message: string;

  constructor(public dialogRef: MatDialogRef<InfoDialogComponent, boolean>) { }

}
