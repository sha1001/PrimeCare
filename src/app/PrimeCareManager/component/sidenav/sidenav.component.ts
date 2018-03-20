import { Component, OnInit, NgZone, ViewChild, AfterViewInit } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import { MatSidenav } from '@angular/material';

const SMALL_WIDTH_BREAKPOINT = 720;

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit, AfterViewInit {

  sidetop = 0;
  sidemarginbottom = 0;

  private mediaMatcher: MediaQueryList =
    matchMedia(`(max-width: ${SMALL_WIDTH_BREAKPOINT}px)`);

  isDarkTheme = false;
  dir = 'ltr';

  constructor(
    zone: NgZone,
    public router: Router) {
    this.mediaMatcher.addListener(mql =>
      zone.run(() => this.mediaMatcher = mql));

  }

  @ViewChild(MatSidenav) sidenav: MatSidenav;


  ngOnInit() {

    console.log('Nitin');

    this.router.events.subscribe(() => {
      console.log('Nitin2');
      if (this.router.url.includes('signin')) {
        this.sidetop = 0;
        this.sidemarginbottom = 0;
        console.log('sidetop1');
       } else {
        this.sidetop = 200;
        this.sidemarginbottom = 50;
        console.log('sidetop2');
       }
    });
   

  }

  ngAfterViewInit() {
    if (this.router.url.includes('signin')) {
      this.sidetop = 0;
      this.sidemarginbottom = 0;
      console.log('sidetop1');
     } else {
      this.sidetop = 200;
      this.sidemarginbottom = 50;
      console.log('sidetop2');
     }
  }

  isScreenSmall(): boolean {
    return this.mediaMatcher.matches;
  }

}
