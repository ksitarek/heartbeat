import { Component } from '@angular/core';
import { ThemeSwitchComponent } from './theme-switch/theme-switch.component';

@Component({
  selector: 'hb-navbar',
  imports: [ThemeSwitchComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
})
export class NavbarComponent {}
