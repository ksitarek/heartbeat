import { effect, Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ThemeService {
  readonly #defaultMode = Theme.System;

  public readonly mode = signal<Theme>(
    localStorage.getItem('mode') == null
      ? this.#defaultMode
      : (localStorage.getItem('mode')! as Theme)
  );

  constructor() {
    effect(() => {
      const mode = this.mode();

      localStorage.setItem('mode', mode);

      document.documentElement.classList.toggle(
        'dark',
        this.mode() === Theme.Dark ||
          (this.mode() === Theme.System &&
            window.matchMedia('(prefers-color-scheme: dark)').matches)
      );
    });

    // Listen for changes to the system theme
    window
      .matchMedia('(prefers-color-scheme: dark)')
      .addEventListener('change', (e) => {
        if (this.mode() === Theme.System) {
          document.documentElement.classList.toggle('dark', e.matches);
        }
      });
  }

  public setMode(mode: Theme) {
    this.mode.set(mode);
  }
}

export enum Theme {
  Dark = 'dark',
  Light = 'light',
  System = 'system',
}
