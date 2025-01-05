import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  title: string = "Main Page";

  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private authService: AuthService, @Inject("BASE_URL") private baseUrl: string) {
    let jwtToken = route.snapshot.queryParamMap.get("jwtToken");
    if (jwtToken != null) this.authService.JwtToken = jwtToken;

  }

  onClick() {
    this.httpClient.get<string>(this.baseUrl + "api/WeatherForecast").subscribe(response => console.log(response));
  }
}
