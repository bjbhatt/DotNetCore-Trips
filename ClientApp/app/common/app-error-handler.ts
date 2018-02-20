import { ErrorHandler } from "@angular/core";


export class AppErrorHandler implements ErrorHandler {
    handleError(error: any) {
        alert('An unxpected error occured');
        console.log(error);
    }
}