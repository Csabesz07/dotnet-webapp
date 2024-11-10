import { Component } from '@angular/core';
import { AuthenticationService } from '../../../services/authentication.service';
import { LoginFormGroup } from '../../../constants/form.entities';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { AuthenticationRequest } from '../../../models/request/authentication.request';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor(
    public authService: AuthenticationService,
    public translate: TranslateService,
  ) {}

  public isValidatingCredentials: boolean = false;

  /** Wether the last login attempt was a success or not */
  public isLoginSuccess: boolean = true;

  public loginFormGroup: LoginFormGroup = new FormGroup({
    username: new FormControl<string | null>(null, [Validators.required]),
    password: new FormControl<string | null>(null, [Validators.required]),
  });

  public changeLangauge(): void {
    if(this.translate.currentLang == 'hu')
      this.translate.use('en');
    else
      this.translate.use('hu');
  }

  public login(): void {
    if(this.loginFormGroup.valid)
    {
      this.isValidatingCredentials = true;
      this.authService.login(new AuthenticationRequest(
        this.loginFormGroup.controls.username.value!,
        this.loginFormGroup.controls.password.value!,
      ))
      .subscribe(res => {
        this.isLoginSuccess = res;
        this.loginFormGroup.reset();
        this.isValidatingCredentials = false;        
      });
    }    
  }

  public logout(): void {
    this.authService.logout();
  }
}
