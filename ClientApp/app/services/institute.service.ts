import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { DataService } from './data.service';
import { ServiceParameters } from '../common/service-parameters';

@Injectable()
export class InstituteService extends DataService{
  constructor(http: Http) { 
    super( 
      new ServiceParameters(
        http,
        "organization/institutes/",
        "organization/institutes/",
        "organization/institutes/"));
  }

}
