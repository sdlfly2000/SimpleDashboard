import { Component, Inject } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { environment } from '../../environments/environment';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private authService: AuthService, @Inject("BASE_URL") private baseUrl: string) {

  }

  get IsLogin(): boolean {
    return this.authService.IsValidLogin;
  }

  get DisplayUserName(): string | null {
    return this.authService.UserDisplayName;
  }

  Logout() {
    this.authService.CleanLocalCache();
  }

  GoToLogin() {
    window.location.href = environment.AuthServiceBaseUrl + "#/login?returnUrl=" + this.baseUrl;
  }

  GoToRegister() {
    window.location.href = environment.AuthServiceBaseUrl;
  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
