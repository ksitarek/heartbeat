import { NgClass } from '@angular/common';
import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SidebarService } from '../../../services/sidebar.service';
import { SidebarMenuItemComponent } from '../sidebar-menu-item/sidebar-menu-item.component';
import { SidebarMenuItem } from './sidebar-menu-item';

@Component({
  selector: 'hb-sidebar-menu',
  imports: [RouterModule, SidebarMenuItemComponent, NgClass],
  templateUrl: './sidebar-menu.component.html',
  styleUrl: './sidebar-menu.component.scss',
})
export class SidebarMenuComponent {
  #sidebarService = inject(SidebarService);

  public get expandSidebar() {
    return this.#sidebarService.expandSidebar;
  }

  public get menuClasses() {
    return this.expandSidebar ? 'mt-8' : '';
  }

  public readonly menuItems: SidebarMenuItem[] = [
    {
      title: 'layout.sidebar.dashboard',
      icon: 'lucideHouse',
      route: '/dashboard',
    },
    { title: 'layout.sidebar.apps', icon: 'lucideCloudCog', route: '/apps' },
  ];
}
