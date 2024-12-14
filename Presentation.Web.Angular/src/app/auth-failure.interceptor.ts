import { HttpErrorResponse, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { tap } from 'rxjs';

@Injectable()
export class AuthFailureInterceptor implements HttpInterceptor {

  constructor(@Inject("BASE_URL") private baseUrl: string) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {

    return next.handle(req)
      .pipe(
        tap({
          error: (err) => {
            if (err instanceof HttpErrorResponse && err.status == 401) {
              window.location.href = "https://homeserver/login?returnUrl=" + this.baseUrl;
            }
          }
        })
      );
  }
}
