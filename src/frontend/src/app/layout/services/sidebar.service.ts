import { effect, Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class SidebarService {
  #expandSidebar = signal(localStorage.getItem('expandSidebar') === 'true');

  constructor() {
    effect(() => {
      localStorage.setItem(
        'expandSidebar',
        this.#expandSidebar() ? 'true' : 'false'
      );
    });
  }

  public get expandSidebar() {
    return this.#expandSidebar();
  }

  public toggleSidebar() {
    this.#expandSidebar.set(!this.#expandSidebar());
  }
}
