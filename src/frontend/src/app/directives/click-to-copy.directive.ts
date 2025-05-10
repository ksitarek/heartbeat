import { Directive, ElementRef, inject, input, NgZone } from '@angular/core';
import { takeUntilDestroyed } from '@angular/core/rxjs-interop';
import { TranslateService } from '@ngx-translate/core';
import { toast } from 'ngx-sonner';
import { combineLatest, fromEvent, switchMap } from 'rxjs';

@Directive({
  selector: '[hbClickToCopy]',
})
export class ClickToCopyDirective {
  public value = input.required<string>({
    alias: 'hbClickToCopy',
  });

  readonly #copyToClipboard = 'layout.copy-to-clipboard';
  readonly #copiedToClipboard = 'layout.copied-to-clipboard';

  #translateService = inject(TranslateService);
  #host = inject(ElementRef<HTMLElement>);
  #zone = inject(NgZone);

  #clipboardWrite$ = fromEvent(this.#host.nativeElement, 'click').pipe(switchMap(() => navigator.clipboard.writeText(this.value())));

  public constructor() {
    this.#translateService
      .stream(this.#copyToClipboard)
      .pipe(takeUntilDestroyed())
      .subscribe((translation) => {
        this.#host.nativeElement.setAttribute('aria-label', translation);
        this.#host.nativeElement.setAttribute('title', translation);
      });

    this.#zone.runOutsideAngular(() => {
      combineLatest([this.#translateService.stream(this.#copiedToClipboard), this.#clipboardWrite$])
        .pipe(takeUntilDestroyed())
        .subscribe(([translation, _]) => {
          toast.info(translation);
        });
    });
  }
}
