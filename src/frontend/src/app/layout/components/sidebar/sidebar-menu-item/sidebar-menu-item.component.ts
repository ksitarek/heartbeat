import { Component, computed, inject, input } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NgIcon } from '@ng-icons/core';
import { HlmButtonDirective } from '@spartan-ng/ui-button-helm';
import { SidebarService } from '../../../services/sidebar.service';
import { SidebarMenuItem } from '../sidebar-menu/sidebar-menu-item';

@Component({
  selector: 'hb-sidebar-menu-item',
  imports: [RouterModule, NgIcon, HlmButtonDirective],
  templateUrl: './sidebar-menu-item.component.html',
  styleUrl: './sidebar-menu-item.component.scss',
})
export class SidebarMenuItemComponent {
  readonly item = input.required<SidebarMenuItem>();

  readonly title = computed(() => this.item().title);
  readonly icon = computed(() => this.item().icon);
  readonly route = computed(() => this.item().route);

  #sidebarService = inject(SidebarService);

  public get expandSidebar() {
    return this.#sidebarService.expandSidebar;
  }
}
