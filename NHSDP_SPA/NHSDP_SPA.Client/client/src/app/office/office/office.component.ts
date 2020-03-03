import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { OfficeService } from 'src/app/services/server/office.service';
import { finalize } from 'rxjs/operators';

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

  constructor(private spinner: NgxSpinnerService,
    private officeService: OfficeService) { }

  ngOnInit() { 
    this.spinner.show();
    
    this.officeService.getAll()
      .pipe(finalize(() => {
        this.spinner.hide();
      }))
      .subscribe(
      offices => {         
        this.dataSource = offices;
      });
  }
}
