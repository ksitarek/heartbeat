import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HlmToasterComponent } from '@spartan-ng/ui-sonner-helm';
import { FooterComponent } from './components/footer/footer.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';

@Component({
  selector: 'hb-layout',
  imports: [
    RouterModule,
    NavbarComponent,
    SidebarComponent,
    FooterComponent,
    HlmToasterComponent,
  ],
  templateUrl: './layout.component.html',
  styleUrl: './layout.component.scss',
})
export class LayoutComponent {}
