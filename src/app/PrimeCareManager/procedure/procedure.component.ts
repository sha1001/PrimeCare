import { Component, AfterViewInit, OnDestroy, Injectable } from '@angular/core';
import { AppDataService } from '../../services/app-data.service';
import { AppDataService2 } from '../../services/app-data.service2';
import { Ord, OrdItem, Procedure, Operation, OperationRoom } from '../../view-models/Ord';
import {Observable} from 'rxjs/Observable';
import { Http } from '@angular/http';


@Component({
  selector: 'app-procedure',
  templateUrl: './procedure.component.html',
  styleUrls: ['./procedure.component.scss']
})
@Injectable()
export class ProcedureComponent implements AfterViewInit, OnDestroy {

  allmedicaldata: Ord[];
  Proc: Procedure;
    count = 0;
    medical: Array<Ord>;
    interval: any;
    currentAddIndex = 0;
    times: Array<number>;

    constructor(private dataService: AppDataService, private http: Http) {  }

    ngAfterViewInit() {
      this.loadComponent();
      this.getTiem();
      this.loadFromFile();
      // this.getDatas();
    }

    loadFromFile() {
      this.http.get('http://localhost:4200/assets/Procedure.json').subscribe(result => {
        this.Proc = result.json() as Procedure;
    }, error => console.error(error));
    console.log(this.Proc);
    }
    loadComponent() {
    if (this.currentAddIndex === 0) {
        this.currentAddIndex = 1;
    } else {
      this.currentAddIndex = 0;
    }
      this.allmedicaldata = this.dataService.ords;
    }

    ngOnDestroy() {
      clearInterval(this.interval);
    }
    getTiem() {
      this.times = [10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0];
    }

    getDatas() {
      this.interval = setInterval(() => {
        this.loadComponent();
      }, 3000);
    }
  }
