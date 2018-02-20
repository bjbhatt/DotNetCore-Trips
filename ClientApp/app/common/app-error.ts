export class AppError {
    constructor(public originalError?: any) {
    }
}

export class NotFoundError extends AppError {
}

export class UnauthorizedError extends AppError {
}

export class BadInput extends AppError {
    public inputErrors: any;
    constructor(public originalError: any) {
        super(originalError);
        this.inputErrors = originalError.json().ModelState;
    }
}