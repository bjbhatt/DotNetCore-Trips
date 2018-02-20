import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import { DataService } from './data.service';
import { ServiceParameters } from '../common/service-parameters';

@Injectable()
export class CanAllocationService extends DataService{
  constructor(http: Http) { 
    super( 
      new ServiceParameters(
        http,
        "organization/divisions/{0}/canallocations/{1}/", 
        "organization/divisions/{0}/canallocations/{1}/updatable/", 
        "organization/canallocations/"));
  }

}
