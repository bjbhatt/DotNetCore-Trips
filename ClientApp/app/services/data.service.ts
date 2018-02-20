import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/catch'; //needed for catching error for an Http Request (operator because it is an instance method) 
import 'rxjs/add/observable/throw'; //needed for Observable.throw static method (observable because it is static method)
import 'rxjs/add/operator/map'; //needed to use map operator for 

import { AppError, UnauthorizedError, NotFoundError,  BadInput } from '../common/app-error';
import { ServiceParameters } from './../common/service-parameters';
import { environment } from '../../environments/environment';


@Injectable()
export class DataService {
  constructor(private serviceParameters: ServiceParameters) { 
    let apiPrefix: string = environment.apiPrefix;
    serviceParameters.listUrl = apiPrefix + serviceParameters.listUrl;
    serviceParameters.listUrlUpdatable = apiPrefix + serviceParameters.listUrlUpdatable;
    serviceParameters.crudUrl = apiPrefix + serviceParameters.crudUrl;
  }

  list(updatable?: boolean, params?: any[]) {
    let url = this.serviceParameters.listUrl;
    if (updatable) {
      url = this.serviceParameters.listUrlUpdatable;
    }
    if (params) {
      for(var i=0; i <= params.length; i++) {
        url = url.replace("{" + i + "}", params[i]);
      }
    }
  
    return this.serviceParameters.http.get(url)
      .map(response => response.json())
      .catch(this.handleError);
  }

  get(id: number) {
    return this.serviceParameters.http.get(this.serviceParameters.crudUrl + id)
      .map(response => response.json())
      .catch(this.handleError);
  }

  create(resource: any) {
    return this.serviceParameters.http.post(this.serviceParameters.crudUrl, JSON.stringify(resource))
      .map(response => response.json())
      .catch(this.handleError);
  }

  update(id: number, resource: any) {
    return this.serviceParameters.http.put(this.serviceParameters.crudUrl  +  id, JSON.stringify(resource))
      .map(response => response.json())
      .catch(this.handleError);
  }

  delete(id: number) {
    return this.serviceParameters.http.delete(this.serviceParameters.crudUrl + id)
      .map(response => response.json())
      .catch(this.handleError);
  }

  
  private handleError(error: Response) {
    switch (error.status) {
      case 400:
        return Observable.throw(new BadInput(error));
      case 403:
        return Observable.throw(new UnauthorizedError());
      case 404:
        return Observable.throw(new NotFoundError());
      default:
        return Observable.throw(new AppError(error));
    }
  }

}
