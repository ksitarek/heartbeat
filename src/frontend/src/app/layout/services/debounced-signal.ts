import { effect, signal, Signal } from '@angular/core';

export const DEFAULT_DEBOUNCE_TIMEOUT = 300;

export function debouncedSignal<T>(
  input: Signal<T>,
  delay: number = DEFAULT_DEBOUNCE_TIMEOUT
): Signal<T> {
  const ds = signal(input());
  let timeout: ReturnType<typeof setTimeout> | null = null;

  effect(() => {
    const value = input();

    if (timeout) {
      clearTimeout(timeout);
    }

    timeout = setTimeout(() => {
      ds.set(value);
    }, delay);
  });

  return ds;
}
