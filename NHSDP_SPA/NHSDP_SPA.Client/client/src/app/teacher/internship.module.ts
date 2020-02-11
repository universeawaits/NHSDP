import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { InternshipComponent } from './internship/internship.component';
import { MatTableModule } from '@angular/material/table';
import { CdkTableModule } from "@angular/cdk/table";



@NgModule({
  declarations: [
    InternshipComponent
  ],
  imports: [
    CommonModule,
    MatTableModule,
    CdkTableModule
  ]
})
export class InternshipModule { }
