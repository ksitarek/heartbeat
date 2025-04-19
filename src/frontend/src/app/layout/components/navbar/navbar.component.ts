import { Component } from '@angular/core';
import { LogoComponent } from '../sidebar/logo/logo.component';
import { ThemeSwitchComponent } from './theme-switch/theme-switch.component';

@Component({
  selector: 'hb-navbar',
  imports: [ThemeSwitchComponent, LogoComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {}
