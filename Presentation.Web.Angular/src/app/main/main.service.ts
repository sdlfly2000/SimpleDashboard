import { HttpHeaders, HttpClient } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { NewUserRequirementModel } from "./models/NewUserRequirementModel";


@Injectable(
  { providedIn: 'root' }
)
export class MainService {
  private httpHeaders: HttpHeaders = new HttpHeaders({ "Content-Type": "application/json", "Access-Control-Allow-Origin": "*" })

  constructor(private httpClient: HttpClient, @Inject("BASE_URL") private BaseUrl: string) {

  }

  NewUserRequirement(title: string, description: string): Observable<string> {
    let model: NewUserRequirementModel = {
      title: title,
      description: description
    };
    return this.httpClient.post<string>(this.BaseUrl + "api/UserRequirement/NewRequirement", JSON.stringify(model), { headers: this.httpHeaders });
  }
}
