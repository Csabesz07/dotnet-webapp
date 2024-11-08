import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  /** The username which will be used for authentication */
  private _username?: string;

  /** The password which will be used for authentication */
  private _password?: string;

  /** Wether the user is currently logged in or not */
  private _isLoggedIn: boolean = false;

  constructor() { }

  public login(username: string, password: string): void {
    this._username = username;
    this._password = password;
    this._isLoggedIn = true;
  }

  public logout(): void {
    this._username = undefined;
    this._password = undefined;
    this._isLoggedIn = false;
  }

  public get isLoggedIn(): boolean {
    return this._isLoggedIn;
  }
}
