import { Component, AfterViewInit, OnInit, OnDestroy, Injectable } from '@angular/core';
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
  list: Procedure[];
    count = 0;
    medical: Array<Ord>;
    interval: any;
    currentAddIndex = 0;
    counter = 0;
    times: number;

    constructor(private dataService: AppDataService, private http: Http) {  }

    ngAfterViewInit() {
      // this.loadComponent();
      // this.getTiem();
      this.loadFromFile();
     // this.loadProcedure();
      this.getDatas();
    }

    loadFromFile() {
      this.http.get('http://localhost:4200/assets/Procedure_full.json').subscribe(result => {
        this.list = result.json() as Procedure[];
        this.Proc = this.list[0];
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
    loadProcedure() {
      if (this.counter === 101) {
        this.counter = 0;
      }
      this.Proc = this.list.filter(
                pro => pro.Id === (this.counter + 1))[0];
        this.counter++;
    }

    ngOnDestroy() {
      clearInterval(this.interval);
    }

    getDatas() {
      this.interval = setInterval(() => {
        this.loadProcedure();
      }, 3000);
    }
  }
