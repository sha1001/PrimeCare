import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-fc-footer',
    templateUrl: './app-fc-footer.component.html',
    styleUrls: ['./app-fc-footer.component.scss']
})

export class FcFooterComponent {
    @Input() public title: string;
}
