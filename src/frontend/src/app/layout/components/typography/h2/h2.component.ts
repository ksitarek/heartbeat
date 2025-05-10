import { Component } from '@angular/core';

@Component({
  selector: 'hb-h2',
  imports: [],
  template: `<h2 class="text-xl mb-5"><ng-content></ng-content></h2>`,
})
export class H2Component {}
