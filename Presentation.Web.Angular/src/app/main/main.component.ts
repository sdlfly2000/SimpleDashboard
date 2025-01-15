import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { QueryStringService } from '../../services/shared.QueryString.service';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent {
  title: string = "Main Page";

  constructor(private httpClient: HttpClient, private route: ActivatedRoute, private authService: AuthService, private queryStringService: QueryStringService, @Inject("BASE_URL") private baseUrl: string) {
    let jwtToken = this.queryStringService.Get("jwtToken");
    let displayName = this.queryStringService.Get("userDisplayName");
    let userId = this.queryStringService.Get("userid");

    if (jwtToken != null) this.authService.JwtToken = jwtToken;
    if (displayName != null) this.authService.UserDisplayName = displayName;
    if (userId != null) this.authService.UserId = userId;

  }

  onClick() {
    this.httpClient.get<string>(this.baseUrl + "api/WeatherForecast").subscribe(response => console.log(response));
  }
}
