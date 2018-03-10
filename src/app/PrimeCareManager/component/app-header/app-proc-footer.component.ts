import { Component, Input } from '@angular/core';

@Component({
    selector: 'app-proc-footer',
    templateUrl: './app-proc-footer.component.html',
    styleUrls: ['./app-proc-footer.component.scss']
})

export class ProcFooterComponent {
    @Input() public title: string;
}
