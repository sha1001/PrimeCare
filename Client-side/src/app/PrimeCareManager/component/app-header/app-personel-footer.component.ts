import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-personel-footer',
    templateUrl: './app-personel-footer.component.html',
    styleUrls: ['./app-personel-footer.component.scss']
})

export class PersonelFooterComponent {
    @Input() public title: string;
}
