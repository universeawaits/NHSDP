import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-course',
  templateUrl: './course.component.html',
  styleUrls: ['./course.component.scss']
})
export class CourseComponent implements OnInit {
  displayedColumns: string[] = [ 'technology', 'hours' ];
  dataSource = [
    { technology: 'ASP.NET Core', hours: '20' }
  ];

  constructor() { }

  ngOnInit(): void { }

}
