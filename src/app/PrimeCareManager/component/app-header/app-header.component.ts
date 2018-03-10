import { Component, Input } from '@angular/core';
import * as moment from 'moment';
import { AfterViewInit, OnDestroy, Injectable, OnInit } from '@angular/core';
import { HeaderDataservice } from '../../../services/header-dataservice';
import { Header } from '../../../view-models/header';
import {Observable} from 'rxjs/Observable';
import { Http } from '@angular/http';

@Component({
    selector: 'app-header',
    templateUrl: './app-header.component.html',
    styleUrls: ['./app-header.component.scss']
})

export class AppHeaderComponent {
    public now: string;
    Header: Header;

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

        public getData(): void {
            this.dataService.getData()
                .subscribe(
                    r => this.Header = r,
                );
        }
    }

