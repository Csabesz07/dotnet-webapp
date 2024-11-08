import { Component } from '@angular/core';
import { AuthenticationService } from '../../../services/authentication.service';
import { LoginFormGroup } from '../../../constants/form.entities';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';

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
      this.authService.login(
        this.loginFormGroup.controls.username.value!,
        this.loginFormGroup.controls.password.value!,
      );

      this.loginFormGroup.reset();
      return;
    }    
  }

  public logout(): void {
    this.authService.logout();
  }
}
