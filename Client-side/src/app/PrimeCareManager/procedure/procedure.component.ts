import { Component, AfterViewInit, OnInit, OnDestroy, Injectable, Renderer2 } from '@angular/core';
import { AppDataService } from '../../services/app-data.service';
import { AppDataService2 } from '../../services/app-data.service2';
import { Ord, OrdItem, Procedure, Operation, OperationRoom } from '../../view-models/Ord';
import {Observable} from 'rxjs/Observable';
import { Http } from '@angular/http';
import {Globals} from '../globals';
import * as d3 from 'd3';
import { Patient } from '../../view-models/patientinfo';
// tslint:disable-next-line:no-unused-expression
import { environment } from '../../../environments/environment';
import { MatDialogsHelperService } from './mat-dialogs-helper/mat-dialogs-helper.service';



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
  globals1: Globals;

  public confirmResult: boolean;

    // tslint:disable-next-line:max-line-length
    constructor(private dataService: AppDataService, private http: Http, private globals: Globals, private dialogs: MatDialogsHelperService) {
      this.globals1 = globals;
     }

     clicked(data: any) {
      this.openConfirmDialogs(data);
    }

    ngAfterViewInit() {
  
      this.loadFromFile();
      this.getDatas();
    }

    public openConfirmDialogs(data: string) {
      if (data != null) {
        this.dialogs.confirm(data).subscribe((res) => (this.confirmResult = res));
      }
    }

    loadFromFile() {
      this.http.get(environment.api_url + '/procedure').subscribe(result => {

        this.Proc = result.json() as Procedure;
    }, error => console.error(error));
  }
    loadComponent() {

      this.allmedicaldata = this.dataService.ords;
    }
    loadProcedure() {
     this.loadFromFile();
    }

    ngOnDestroy() {
      clearInterval(this.interval);
    }

    getDatas() {
      this.interval = setInterval(() => {
        this.loadProcedure();
      }, this.globals1.timeinterval);
    }
  }
