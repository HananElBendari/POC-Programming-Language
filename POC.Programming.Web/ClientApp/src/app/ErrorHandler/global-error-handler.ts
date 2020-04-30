import { ErrorHandler, Injectable, Injector, NgZone } from '@angular/core';
import { NotificationService } from '../services/notification.service';
import { ErrorsLogService } from '../services/errors-log.service';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class GlobalErrorHandler implements ErrorHandler {

    constructor(private injector: Injector, private ngZone: NgZone) {
     }

    handleError(error: Error) {
        const toastr = this.injector.get(NotificationService);
        const errorsLogService = this.injector.get(ErrorsLogService);

        this.ngZone.run(() => {
            toastr.showError(`Something went wrong! ${error.message}`, 'Error');
        });

        if (error instanceof HttpErrorResponse) {
            errorsLogService.logError(error).subscribe(() => {});
        }
        console.log(error);

    }
}
