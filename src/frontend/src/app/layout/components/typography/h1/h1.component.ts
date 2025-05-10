import { Component } from '@angular/core';

@Component({
  selector: 'hb-h1',
  imports: [],
  template: `<h1 class="text-3xl"><ng-content></ng-content></h1>`,
})
export class H1Component {}
