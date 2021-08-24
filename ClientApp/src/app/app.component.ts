import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ClientApp';

  get isUserAuthenticated(): boolean {
    const token: string | null = localStorage.getItem('jwt');
    if(token){
      return true;
    }else{
      return false;
    }
  }
}
