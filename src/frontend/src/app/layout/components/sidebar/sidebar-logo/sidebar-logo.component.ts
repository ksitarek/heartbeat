import { NgClass } from '@angular/common';
import { Component, inject } from '@angular/core';
import { SidebarService } from '../../../services/sidebar.service';

@Component({
  selector: 'hb-sidebar-logo',
  imports: [NgClass],
  templateUrl: './sidebar-logo.component.html',
  styleUrl: './sidebar-logo.component.scss',
})
export class SidebarLogoComponent {
  #sidebarService = inject(SidebarService);

  public get expandSidebar() {
    return this.#sidebarService.expandSidebar;
  }

  public get sidebarLogoClasses() {
    return this.expandSidebar ? 'justify-between' : 'justify-center';
  }
}
