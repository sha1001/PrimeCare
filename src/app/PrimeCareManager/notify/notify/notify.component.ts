import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-notify',
  templateUrl: './notify.component.html',
  styleUrls: ['./notify.component.scss']
})
export class NotifyComponent {

 // setting this is the key to initial select.
 selectedValue = 'showall';
 selectedValueEmergence = 'showemergence';
 selectedValueAnes4 = 'showAnes4';
 selectedreadyfi = 'showreadyfi';
 selectedValuetrigger = 'showtrigger';
}
