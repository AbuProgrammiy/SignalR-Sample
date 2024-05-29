import { Injectable } from '@angular/core';
import * as SignalR from '@microsoft/signalr' // SignalR shunday impoert qilinadi

@Injectable({
  providedIn: 'root'
})
export class AppService {

  constructor() { 
    this.hubConnection=new SignalR.HubConnectionBuilder().withUrl("https://localhost:7290/notificationHub/").build()
    //                                                                                    ^^^^^^^^^^^^^^^ -> qoshimcha routni togri yozish kerak,
    //                                                                                                       agar route bolmasa ohiri / bolishi kerak

    this.hubConnection.start().catch((err)=>{
      //               ^^^^^ -> connectionni ulaydi, xatolik bolsa consolga chiqaradi
      console.log(err)
    })
  }

  private hubConnection!:SignalR.HubConnection

  public ReceiveMessage(callback:(message:string)=>void):void{
    this.hubConnection.on('ReceiveNotification',callback)
    //                     ^^^^^^^^^^^^^^^^^^^ -> method [_hubContext.Clients.All.SendAsync] ichidagi bilan birxil bo'lishi lozim
  }
}
