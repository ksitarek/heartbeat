import { JsonPipe } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { PageComponent } from '../../../layout/components/page/page.component';
import { AppsListService } from './apps-list.service';

@Component({
  selector: 'hb-apps-list',
  imports: [PageComponent, JsonPipe],
  templateUrl: './apps-list.component.html',
  styleUrl: './apps-list.component.scss',
})
export class AppsListComponent implements OnInit {
  #appsListService = inject(AppsListService);

  public readonly apps = this.#appsListService.apps;

  public ngOnInit(): void {
    this.#appsListService.load();
  }
}
