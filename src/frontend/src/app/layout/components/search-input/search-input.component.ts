import { Component, effect, signal } from '@angular/core';
import {
  ControlValueAccessor,
  FormsModule,
  NG_VALUE_ACCESSOR,
} from '@angular/forms';
import { NgIcon } from '@ng-icons/core';
import { HlmInputDirective } from '@spartan-ng/ui-input-helm';

@Component({
  selector: 'hb-search-input',
  imports: [NgIcon, FormsModule, HlmInputDirective],
  templateUrl: './search-input.component.html',
  styleUrl: './search-input.component.scss',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      multi: true,
      useExisting: SearchInputComponent,
    },
  ],
})
export class SearchInputComponent implements ControlValueAccessor {
  public readonly value = signal('');

  public readonly disabled = signal(false);

  public constructor() {
    effect(() => {
      this.#onChange(this.value());
      this.#onTouched();
    });
  }

  #onChange: (value: string) => void = () => {};

  #onTouched: () => void = () => {};

  writeValue(value: string): void {
    this.value.set(value);
  }
  registerOnChange(fn: any): void {
    this.#onChange = fn;
  }
  registerOnTouched(fn: any): void {
    this.#onTouched = fn;
  }
  setDisabledState?(isDisabled: boolean): void {
    this.disabled.set(isDisabled);
  }
}
