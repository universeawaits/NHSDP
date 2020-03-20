import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Title } from '@angular/platform-browser';
import { SnackbarService } from 'src/app/services/component/snackbar.service';
import { AuthService } from 'src/app/core/authentication/auth.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  constructor(
    private router: Router,
    private authService: AuthService,
    private snackbarService: SnackbarService,
    private titleService: Title,
    private spinner: NgxSpinnerService
  ) { }

  ngOnInit() {
    this.titleService.setTitle('noedge :: login');
  }

  // submit() {
  //   this.spinner.show();
  //   this.authService.login({
  //       UserName: this.loginForm.get('login').value, 
  //       Password: this.loginForm.get('password').value
  //     })
  //     .then(
  //       () => {
  //         // localStorage.setItem("jwt:token", response.token),
  //         // localStorage.setItem("jwt:email", response.email)
  //         this.router.navigateByUrl('/profile');
  //       },
  //       response => {
  //         this.snackbarService.open(response.error, false);
  //       }
  //     );
  // }

  googleRedirect() {
    this.authService.googleRedirect();
  }

  onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
  }
}
