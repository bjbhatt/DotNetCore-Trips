import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { DataService } from './data.service';
import { ServiceParameters } from '../common/service-parameters';

@Injectable()
export class BranchService extends DataService{
  constructor(http: Http) {
    super( 
      new ServiceParameters(
        http,
        "organization/divisions/{0}/branches/", 
        "organization/divisions/{0}/branches/updatable/", 
        "organization/branches/"));
  }

}
