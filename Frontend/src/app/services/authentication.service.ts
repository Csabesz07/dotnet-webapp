import { Injectable } from '@angular/core';
import { API_BASE, PASSWORD, USERNAME } from '../constants/api';
import { catchError, map, Observable, of } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { AuthenticationRequest } from '../models/request/authentication.request';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  /** Wether the user is currently logged in or not */
  private _isLoggedIn: boolean = false;  

  constructor(private http: HttpClient) { }

  public login(credentials: AuthenticationRequest): Observable<boolean> {
    window.localStorage.setItem(USERNAME, credentials.username);
    window.localStorage.setItem(PASSWORD, credentials.password);

    return this.http.post(API_BASE + 'Authentication/Login', credentials, {observe: 'response'})
    .pipe(
      map(res => {
        if(res.ok)
          this._isLoggedIn = true;

        return res.ok;
      }),
      catchError(() => of(false))
    );
  }

  public logout(): void {
    window.localStorage.removeItem(USERNAME);
    window.localStorage.removeItem(PASSWORD);    
    this._isLoggedIn = false;
  }

  public get isLoggedIn(): boolean {
    return this._isLoggedIn;
  }
}
