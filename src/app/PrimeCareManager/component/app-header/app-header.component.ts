import { Component, Input, ViewChild} from '@angular/core';
import * as moment from 'moment';
import { AfterViewInit, OnDestroy, Injectable, OnInit } from '@angular/core';
import { HeaderDataservice } from '../../../services/header-dataservice';
import { Header } from '../../../view-models/header';
import {Observable} from 'rxjs/Observable';
import { Http } from '@angular/http';
import { Procedure } from '../../../view-models/ord';

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

    chartOptions = {
        responsive: true
      };
      chartData = [
        { data: [8 , 5, 3, 2], label: 'Forecast' }
      ];

      // tslint:disable-next-line:max-line-length
      chartLabels = ['5:00 AM', '7:00 AM', '9:00 AM', '11:00 AM' ];

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

    constructor(private dataService: HeaderDataservice, private http: Http) {
        this.now = moment().format('YYYY-MM-DDTHH:mm:ss');
        this.getData();
        }
    ngAfterViewInit() {
        this.loadFromFile();
        this.getDatas();
          }

          loadFromFile() {
            this.http.get('http://localhost:4200/assets/Procedure_full.json').subscribe(result => {
              this.list = result.json() as Procedure[];
              this.timeDisplay = this.list[0].CurrentTime;
          }, error => console.error(error));
          console.log(this.list);
          }
          loadProcedure() {
            if (this.counter === 101) {
              this.counter = 0;
            }
            this.timeDisplay = this.list.filter(
                      pro => pro.Id === (this.counter + 1))[0].CurrentTime;
              this.counter++;
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
    }

