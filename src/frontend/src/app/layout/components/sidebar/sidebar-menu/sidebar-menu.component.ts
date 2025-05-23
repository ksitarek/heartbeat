import { Component, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SidebarService } from '../../../services/sidebar.service';
import { SidebarMenuItemComponent } from '../sidebar-menu-item/sidebar-menu-item.component';
import { SidebarMenuItem } from './sidebar-menu-item';

@Component({
  selector: 'hb-sidebar-menu',
  imports: [RouterModule, SidebarMenuItemComponent],
  templateUrl: './sidebar-menu.component.html',
  styleUrl: './sidebar-menu.component.scss',
})
export class SidebarMenuComponent {
  #sidebarService = inject(SidebarService);

  public get expandSidebar() {
    return this.#sidebarService.expandSidebar;
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
