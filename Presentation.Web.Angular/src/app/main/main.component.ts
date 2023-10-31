import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../auth.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  title: string = "Main Page";

  constructor(private httpClient: HttpClient, private route: ActivatedRoute) {
    let jwtToken = route.snapshot.queryParamMap.get("jwtToken");
    if (jwtToken != null) AuthService.JwtToken = jwtToken;

    httpClient.get<string>("api/WeatherForecast").subscribe(response => console.log(response));
  }
}
