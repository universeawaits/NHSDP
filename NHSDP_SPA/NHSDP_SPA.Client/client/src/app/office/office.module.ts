import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table';
import { CdkTableModule } from "@angular/cdk/table";
import { OfficeComponent } from './office/office.component';



@NgModule({
  declarations: [
    OfficeComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    CdkTableModule
  ]
})
export class OfficeModule { }
