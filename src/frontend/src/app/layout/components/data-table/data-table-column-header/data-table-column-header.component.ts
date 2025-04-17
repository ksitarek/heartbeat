import { Component, input, model } from '@angular/core';
import { NgIcon } from '@ng-icons/core';
import { HlmButtonDirective } from '@spartan-ng/ui-button-helm';
import { HlmIconDirective } from '@spartan-ng/ui-icon-helm';

@Component({
  selector: 'hb-data-table-column-header',
  imports: [NgIcon, HlmButtonDirective, HlmIconDirective],
  templateUrl: './data-table-column-header.component.html',
  styleUrl: './data-table-column-header.component.scss',
})
export class DataTableColumnHeaderComponent {
  public readonly key = input.required<string>();
  public readonly sortBy = model.required<string>();
  public readonly sortOrder = model.required<string>();

  protected updateSort(): void {
    if (this.sortBy() === this.key()) {
      this.sortOrder.set(this.sortOrder() === 'asc' ? 'desc' : 'asc');
    } else {
      this.sortBy.set(this.key());
      this.sortOrder.set('asc');
    }
  }

  public get sortIcon(): string {
    if (this.sortBy() !== this.key()) {
      return 'lucideChevronsUpDown';
    }

    return this.sortOrder() === 'desc'
      ? 'lucideChevronDown'
      : 'lucideChevronUp';
  }
}
