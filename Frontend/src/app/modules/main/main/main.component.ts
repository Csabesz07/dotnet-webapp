import { Component } from '@angular/core';
import { AuthenticationService } from '../../../services/authentication.service';
import { Right } from '../../../enums/right.enum';

@Component({
  selector: 'main',
  templateUrl: './main.component.html',
  styleUrl: './main.component.scss'
})
export class MainComponent {

  /** Created to eliminate magic numbers in html template */
  public rights = Right;

  constructor(public authService: AuthenticationService) {}
}
