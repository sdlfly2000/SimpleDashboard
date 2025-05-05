import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { AuthInterceptor } from './auth.interceptor';
import { AuthFailureInterceptor } from './auth-failure.interceptor';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { QueryStringService } from '../services/shared.QueryString.service';
import { AuthService } from '../services/auth.service';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeng/themes/aura';

import { ButtonModule } from 'primeng/button';
import { InputTextModule } from 'primeng/inputtext';
import { NavSiteMapComponent } from './nav-sitemap/nav-sitemap.component';
import { MainService } from './main/main.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    NavSiteMapComponent,
    MainComponent
  ],
  bootstrap: [AppComponent],
  imports: [
    BrowserModule,
    FormsModule,
    ButtonModule,
    InputTextModule,
    RouterModule.forRoot([
        { path: '', component: MainComponent, pathMatch: 'full' },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthFailureInterceptor, multi: true },
    { provide: "BASE_URL", useValue: document.getElementsByTagName('base')[0].href },
    { provide: AuthService },
    { provide: QueryStringService },
    { provide: MainService },
    provideHttpClient(withInterceptorsFromDi()),
    provideAnimationsAsync(),
    providePrimeNG({
      theme: {
        preset: Aura
      }
    })
  ]
})
export class AppModule { }
