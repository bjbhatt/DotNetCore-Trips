import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { DataService } from './data.service';
import { ServiceParameters } from '../common/service-parameters';

@Injectable()
export class DivisionService extends DataService{
  constructor(http: Http) { 
    super( 
      new ServiceParameters(
        http,
        "organization/institute/{0}/divisions/", 
        "organization/institute/{0}divisions/updatable/", 
        "organization/divisions/"));
  }

}
