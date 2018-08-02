import { Component, Input, ViewChild } from '@angular/core';
import * as moment from 'moment';
import { AfterViewInit, OnDestroy, Injectable, OnInit } from '@angular/core';
import { HeaderDataservice } from '../../../services/header-dataservice';
import { Header } from '../../../view-models/header';
import { Observable } from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Procedure } from '../../../view-models/ord';
import { Globals } from '../../globals';
import { Alert } from '../../../view-models/alert';
import { HeaderChart } from '../../../view-models/headerchart';
import * as Chart from 'chart.js';


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
    if (!this.list) {
      this.http.get('http://primecaredev.centralus.cloudapp.azure.com/api/fake/procedure').subscribe(result => {
        this.list = result.json() as Procedure[];
        this.timeDisplay = this.list[0].CurrentTime;
        this.alert = this.list[0].Alert;
      }, error => console.error(error));
    }
  }
  loadProcedure() {
    if (this.counter === 101) {
      this.counter = 0;
    }
    this.timeDisplay = this.list.filter(
      pro => pro.Id === (this.counter + 1))[0].CurrentTime;
    this.alert = this.list.filter(
      pro => pro.Id === (this.counter + 1))[0].Alert;
    this.globals.currentCounter = this.counter++;
  }
  getDatas() {
    this.interval = setInterval(() => {
      this.loadProcedure();
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
      .get('assets/headerchart.json')
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
