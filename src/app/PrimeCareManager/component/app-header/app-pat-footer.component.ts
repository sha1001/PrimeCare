import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-pat-footer',
    templateUrl: './app-pat-footer.component.html',
    styleUrls: ['./app-pat-footer.component.scss']
})

export class PatFooterComponent {
    @Input() public title: string;
}
