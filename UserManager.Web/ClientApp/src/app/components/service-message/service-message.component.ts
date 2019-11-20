import { Component, OnInit } from '@angular/core';

import { MessageService } from '../../services/message.service';

@Component({
    selector: 'app-service-message',
    templateUrl: './service-message.component.html',
    styleUrls: ['./service-message.component.css']
})
export class ServiceMessageComponent implements OnInit {
    constructor(public messageService: MessageService) { }

    ngOnInit() { }
}
