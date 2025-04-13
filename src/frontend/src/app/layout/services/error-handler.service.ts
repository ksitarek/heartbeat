import { Injectable } from '@angular/core';
import { toast } from 'ngx-sonner';
import { EMPTY, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class ErrorHandlerService {
  public handleHttpError(error: unknown): Observable<never> {
    console.error('An HTTP error occurred:', error);

    toast.error('HTTP connectivity issue', {
      description: 'Seems like our API is unreachable. Please try again later.',
      duration: 5000,
      action: {
        label: 'Dismiss',
        onClick: () => {},
      },
    });

    return EMPTY;
  }
}
