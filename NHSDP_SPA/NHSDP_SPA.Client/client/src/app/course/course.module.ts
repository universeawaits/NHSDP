import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseComponent } from './course/course.component';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [
    CourseComponent
  ],
  imports: [
    CommonModule,
    MatTableModule
  ]
})
export class CourseModule { }
