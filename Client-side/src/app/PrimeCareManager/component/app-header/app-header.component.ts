import { Component, Input, ViewChild } from '@angular/core';
import * as moment from 'moment';
import { AfterViewInit, OnDestroy, Injectable, OnInit } from '@angular/core';
import { HeaderDataservice } from '../../../services/header-dataservice';
import { Header } from '../../../view-models/header';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Procedure } from '../../../view-models/Ord';
import { Globals } from '../../globals';
import { Alert } from '../../../view-models/alert';
import { HeaderChart } from '../../../view-models/headerchart';
import * as Chart from 'chart.js';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.scss']
})

export class AppHeaderComponent implements AfterViewInit {
  public now: string;
  timeDisplay: string;
  Header: Header;
  interval: any;
  list: Procedure[];
  procedure: Procedure;
  counter = 0;
  items: Alert[];
  headerchart: HeaderChart;
  alert: string[];

  canvas: any;
  ctx: any;

  constructor(private dataService: HeaderDataservice, private http: Http, public globals: Globals) {
    this.now = moment().format('MM/DD/YYYY');
    this.getData();
    this.loadHeaderChartData();
    this.counter = globals.currentCounter;
  }
  ngAfterViewInit() {
    this.loadFromFile();
    this.getDatas();
    this.loadHeaderChartData();
  }
  loadFromFile() {
      this.http.get(environment.api_url + '/procedure').subscribe(result => {
        this.procedure = result.json() as Procedure;
        this.alert = this.procedure.Alert;
      }, error => console.error(error));
  }
  loadProcedure() {
    this.loadFromFile();
  }
  getDatas() {
    this.interval = setInterval(() => {
      this.loadProcedure();
      this.globals.currentCounter = this.counter++;
    }, 3000);
  }
  public getData(): void {
    this.dataService.getData()
      .subscribe(
        r => this.Header = r,
    );
  }

  loadHeaderChartData() {
    this.http
      .get(environment.api_url + '/headerchart')
      .map(data => data.json() as HeaderChart)
      .subscribe(data => {
        this.headerchart = data;
        this.canvas = document.getElementById('myChart');
        this.ctx = this.canvas.getContext('2d');
        // tslint:disable-next-line:prefer-const
        let myChart = new Chart(this.ctx, {
          type: 'bar',
          data: {
            labels: this.headerchart.hchartlabels,
            datasets: [{
              label: this.headerchart.hchartdatasetlabel,
              data: this.headerchart.hchartdataset,
              backgroundColor: this.headerchart.hchartbackgroundColor,
              pointBackgroundColor: this.headerchart.hchartbackgroundColor,
              borderColor:this.headerchart.hchartbackgroundColor,
              pointBorderColor:this.headerchart.hchartbackgroundColor,
              fill: false,
              borderWidth: 1
            }]
          },
          options: {
            responsive: false,
          }
        });
      });
  }
}

