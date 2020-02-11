import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-internship',
  templateUrl: './internship.component.html',
  styleUrls: ['./internship.component.scss']
})
export class InternshipComponent implements OnInit {
  displayedColumns: string[] = [ 'name', 'startAt', 'endAt', 'maxS', 'currS'];
  dataSource = [
    { name: 'ASP.NET Developer', startAt: '02/02/2020', endAt: '02/05/2020', maxStudentsCount: 40, currentStudentsCount: 20 }
  ];

  constructor() { }

  ngOnInit(): void { }

}
