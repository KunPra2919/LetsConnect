import { Global } from '../../Shared/global';
import { Component, OnInit } from '@angular/core';
import { HubConnection } from '@aspnet/signalr';
import * as signalR from '@aspnet/signalr';
import { HomeService } from '../../Service/home.service';
import { Observable } from 'rxjs/Rx';


@Component({
    templateUrl: './message.component.html'
})

export class MessageComponent implements OnInit {

    private hubConnection: signalR.HubConnection;
    nick: string = '';
    message: string = 'hello';
    messages: string[] = [];

    constructor(private _homeService: HomeService) { }

    ngOnInit() {

        this.hubConnection = new signalR.HubConnectionBuilder()
            .withUrl("/LetsConnectHub")
            .build();

        this.hubConnection
            .start()
            .then(() => {
                console.log('Connection started!');
                console.log(Global.BASE_HOME_ENDPOINT);

            })
            .catch(err => console.log('Error while establishing connection :(', err));

        this.hubConnection.on("ReceiveMessage", (sender, message)=>{            
            this.messages.push(message);
        });

    }

    sendMessage(): void {


        this._homeService.get(Global.BASE_HOME_ENDPOINT + '/SendMessage?msg=' + this.message).subscribe(
            data => {
                if (data != "") //Success
                {         
                    this.message = "";
                }
                else {

                }

            },
            error => {

            }
        );
    }

}
