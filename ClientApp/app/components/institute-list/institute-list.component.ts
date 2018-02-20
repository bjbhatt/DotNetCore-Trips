import { Component, OnInit } from '@angular/core';
import { InstituteService } from './../../services/institute.service';
import { AppError, NotFoundError, UnauthorizedError } from './../../common/app-error';

@Component({
  selector: 'app-institute-list',
  templateUrl: './institute-list.component.html',
  styleUrls: ['./institute-list.component.css']
})
export class InstituteListComponent implements OnInit {
  
  institutes: any[];

  constructor(private instituteService : InstituteService) { }

  ngOnInit() {
    this.instituteService.list() 
      .subscribe(objects => {
        this.institutes = objects;
      },
      (error: AppError) => {
        if (error instanceof NotFoundError) {
          alert('Institute(s) Not Found');
        } else if (error instanceof UnauthorizedError) {
          alert('You do not have access to view Institutes list');
        } else {
          throw error;
        }
      });
  }

}
