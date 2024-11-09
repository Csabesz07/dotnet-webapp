import { Injectable } from '@angular/core';
import { Right } from '../enums/right.enum';
import { WRITE_PASSWORD, WRITE_USERNAME } from '../constants/api';

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

  private _right: Right = Right.read;

  constructor() { }

  public login(username: string, password: string): void {
    this._username = username;
    this._password = password;
    this._isLoggedIn = true;

    if(username == WRITE_USERNAME && password == WRITE_PASSWORD) {
      this._right = Right.write;
    }
  }

  public logout(): void {
    this._username = undefined;
    this._password = undefined;
    this._isLoggedIn = false;
    this._right = Right.read;
  }

  public get isLoggedIn(): boolean {
    return this._isLoggedIn;
  }

  public get right(): Right {
    return this._right;
  }

  public get username(): string | undefined {
    return this._username;
  }

  public get password(): string | undefined {
    return this._password;
  }
}
