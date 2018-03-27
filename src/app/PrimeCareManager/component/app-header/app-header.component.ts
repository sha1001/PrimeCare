import { Component, Input, ViewChild} from '@angular/core';
import * as moment from 'moment';
import { AfterViewInit, OnDestroy, Injectable, OnInit } from '@angular/core';
import { HeaderDataservice } from '../../../services/header-dataservice';
import { Header } from '../../../view-models/header';
import {Observable} from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Procedure } from '../../../view-models/ord';
import {Globals} from '../../globals';
import { Alert } from '../../../view-models/alert';

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
    // tslint:disable-next-line:max-line-length
    items: Alert[];
    alert: string[];

    chartOptions = {
        responsive: true
      };
      chartData = [
        { data: [8 , 5, 3, 2], label: 'Forecast after 5pm' }
      ];

      // tslint:disable-next-line:max-line-length
      chartLabels = ['5:00 PM', '7:00 PM', '9:00 PM', '11:00 PM' ];

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
      }

    constructor(private dataService: HeaderDataservice, private http: Http, public globals: Globals) {
        this.now = moment().format('MM/DD/YYYY');
        this.getData();
        this.counter = globals.currentCounter;
        }
    ngAfterViewInit() {
        this.loadFromFile();
        this.getDatas();
        this.loadAlertData();
          }

          loadFromFile() {
              if (!this.list) {
            this.http.get('assets/Procedure_full.json').subscribe(result => {
              this.list = result.json() as Procedure[];
              this.timeDisplay = this.list[0].CurrentTime;
              this.alert = this.list[0].Alert;
          }, error => console.error(error));
          console.log(this.list);
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

        loadAlertData() {
        this.http.get('assets/alert.json').subscribe(result => {
          this.items = result.json() as Alert[];
      }, error => console.error(error));
      console.log(this.list);
      }
    }

