import { NgClass } from '@angular/common';
import { Component, inject } from '@angular/core';
import { NgIcon } from '@ng-icons/core';
import { TranslatePipe } from '@ngx-translate/core';
import { HlmButtonDirective } from '@spartan-ng/ui-button-helm';
import { SidebarService } from '../../services/sidebar.service';
import { SidebarMenuComponent } from './sidebar-menu/sidebar-menu.component';

@Component({
  selector: 'hb-sidebar',
  imports: [
    NgClass,
    HlmButtonDirective,
    NgIcon,
    SidebarMenuComponent,
    TranslatePipe,
  ],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.scss',
})
export class SidebarComponent {
  #sidebarService = inject(SidebarService);

  public get expandSidebar() {
    return this.#sidebarService.expandSidebar;
  }

  public get sidebarClasses() {
    return this.expandSidebar ? 'w-[210px] xl:w-[280px] px-8' : 'w-[70px]';
  }

  public toggleSidebar() {
    this.#sidebarService.toggleSidebar();
  }
}
