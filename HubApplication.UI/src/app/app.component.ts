import { Component } from '@angular/core';
import { AppService } from './app.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'HubApplication.UI';

  constructor(private notificationService:AppService){
    notificationService.ReceiveMessage((message)=>{
      window.alert(message)
    })
  }
}
