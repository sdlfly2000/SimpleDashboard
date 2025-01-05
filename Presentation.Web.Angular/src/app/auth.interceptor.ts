import { HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  public authToken: string | null = "";

  constructor(private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler) {
    this.authToken = this.authService.JwtToken;

    if (this.authToken != "" || this.authToken != null) {
      const authReq = req.clone({
        headers: req.headers.set("Authorization", "Bearer " + this.authToken)
      });
      // send cloned request with header to the next handler.
      return next.handle(authReq);
    }

    return next.handle(req);
  }
}
