import { Component, OnInit } from '@angular/core';
import { AfterViewInit, OnDestroy, Injectable } from '@angular/core';
import { FacilityDataservice } from '../../services/facility.dataservice';
import { BedItem, OperationBed, Bed, Resources } from '../../view-models/Bed';
import {Observable} from 'rxjs/Observable';
import { Http } from '@angular/http';
import {Globals} from '../globals';

@Component({
  selector: 'app-facilityresources',
  templateUrl: './facilityresources.component.html',
  styleUrls: ['./facilityresources.component.scss']
})

@Injectable()
export class FacilityresourcesComponent implements  AfterViewInit {

  Bed: Bed;
  resource: Resources;
  listResource: Resources[];
  interval: any;
  globals1: Globals;

  chartOptions = {
    responsive: true
  };

  chartData = [
    { data: [10 , 15, 25, 30, 35, 40, 90, 80, 70, 55, 40, 35, 25, 15 ], label: 'PACU occupancy forecast' }
  ];

  // tslint:disable-next-line:max-line-length
  chartLabels = ['8:00 AM', '9:00 AM', '10:00 AM', '11:00 AM', '12:00 PM', '1:00 PM', '2:00 PM', '3:00 PM', '4:00 PM', '5:00 PM', '6:00 PM', '7:00 PM',  '8:00 PM', '9:00 PM' ];

  public chartColors: any[] = [
    {
      backgroundColor : '#0062ff',
      pointBackgroundColor: '#0062ff',
      pointHoverBackgroundColor: '#0062ff',
      borderColor: '#0062ff',
      pointBorderColor: '#0062ff',
      pointHoverBorderColor: '#0062ff',
      fill: false /* this option hide background-color */
    }];

  onChartClick(event) {
    console.log(event);
  }

  constructor(private dataService: FacilityDataservice, private http: Http, private globals: Globals) {
    this.globals1 = globals;
    }

  ngAfterViewInit() {
    this.loadFromFile();
    this.getDatas();
  }
  loadFromFile() {
    this.http.get('assets/Resource.json').subscribe(result => {
      // tslint:disable-next-line:no-debugger
      // debugger;
      this.listResource = result.json() as Resources[];
      this.resource = this.listResource[this.globals1.currentCounter];
    }, error => console.error(error));
    console.log(this.Bed);
  }
  getDatas() {
    this.interval = setInterval(() => {
      this.loadResource();
    }, 3000);
  }

  loadResource() {
    /* if (this.counter === 101) {
      this.counter = 0;
    } */
    this.resource = this.listResource.filter(
              pro => pro.Id === (this.globals1.currentCounter))[0];
     // this.counter++;
  }
}
