import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserProfileComponent } from './profile/user-profile/user-profile.component';
import { UserRegisterComponent } from './auth/register/user-register/user-register.component';
import { AuthComponent } from './auth/auth/auth.component';
import { AuthGuard } from './auth/auth.guard';
import { InternshipComponent } from './internship/internship/internship.component';
import { CourseComponent } from './course/course/course.component';
import { OfficeComponent } from './office/office/office.component';

const routes: Routes = [
  { path: '', redirectTo: 'internships', pathMatch: 'full' },
  { path: 'my', component: UserProfileComponent, canActivate: [ AuthGuard ] },
  { path: 'register', component: UserRegisterComponent },
  { path: 'login', component: AuthComponent },
  { path: 'internships', component: InternshipComponent },
  { path: 'courses', component: CourseComponent },
  { path: 'offices', component: OfficeComponent },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
