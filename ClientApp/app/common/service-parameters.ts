import { Http } from '@angular/http';

export class ServiceParameters {
    constructor(public http: Http, public listUrl: string, public listUrlUpdatable: string, public crudUrl: string) {
    }
}