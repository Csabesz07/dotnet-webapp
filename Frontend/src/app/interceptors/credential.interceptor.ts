import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PASSWORD, USERNAME } from '../constants/api';

@Injectable()
export class CredentialInterceptor implements HttpInterceptor {

    constructor() {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        req = req.clone({
        setHeaders: {        
            'Content-Type' : 'application/json; charset=utf-8',
            'Accept'       : 'application/json',
            'Authorization': [
                window.localStorage.getItem(USERNAME) ?? '', 
                window.localStorage.getItem(PASSWORD) ?? '',
            ],
        },
        });

        return next.handle(req);
    }
}