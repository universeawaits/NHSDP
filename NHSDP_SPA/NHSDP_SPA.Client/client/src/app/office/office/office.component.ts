import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-office',
  templateUrl: './office.component.html',
  styleUrls: ['./office.component.scss']
})
export class OfficeComponent implements OnInit {
  displayedColumns: string[] = [ 'location', 'cabinetsCount' ];
  dataSource = [
    { location: 'Levkova, 1', cabinetsCount: 12 }
  ];

  constructor(private spinner: NgxSpinnerService) { }

  ngOnInit() { 
    this.spinner.show();
  }

}
