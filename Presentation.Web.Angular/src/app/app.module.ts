import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AuthInterceptor } from './auth.interceptor';
import { AuthFailureInterceptor } from './auth-failure.interceptor';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { AuthService } from './auth.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: MainComponent, pathMatch: 'full' },
    ]),
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: AuthFailureInterceptor, multi: true},
    { provide: "BASE_URL", useValue: document.getElementsByTagName('base')[0].href },
    { provide: AuthService }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
