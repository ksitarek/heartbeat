import { Component, inject } from '@angular/core';
import { NgIcon } from '@ng-icons/core';
import {
  BrnToggleGroupComponent,
  BrnToggleGroupItemDirective,
} from '@spartan-ng/brain/toggle-group';
import {
  HlmToggleGroupDirective,
  HlmToggleGroupItemDirective,
} from '../../../../../../libs/ui/ui-togglegroup-helm/src/index';
import { Theme, ThemeService } from '../../../services/theme.service';

@Component({
  selector: 'hb-theme-switch',
  imports: [
    HlmToggleGroupDirective,
    HlmToggleGroupItemDirective,
    BrnToggleGroupItemDirective,
    BrnToggleGroupComponent,
    NgIcon,
  ],
  templateUrl: './theme-switch.component.html',
  styleUrl: './theme-switch.component.scss',
})
export class ThemeSwitchComponent {
  #themeService = inject(ThemeService);
  public Theme: typeof Theme = Theme;

  public get mode() {
    return this.#themeService.mode();
  }

  public setMode(mode: Theme) {
    this.#themeService.setMode(mode);
  }
}
