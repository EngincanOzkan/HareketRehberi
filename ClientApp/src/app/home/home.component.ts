import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  exampleData: any;
  
  constructor(
    private http: HttpClient
  ) { }

  ngOnInit(): void {
    this.http.get("https://localhost:5001/api/weatherforecast").subscribe(response => {
      this.exampleData = response;
      console.log(this.exampleData);
    }, err => {
      console.log(err);
    })
  }

}
