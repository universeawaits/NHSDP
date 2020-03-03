import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl, NgForm } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { SnackbarService } from 'src/app/services/component/snackbar.service';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/core/authentication/auth.service';


@Component({
  selector: 'user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {
  mode: string = 'view';
  changeModeIcon: string = 'edit';

  avatarSrc: string;
  avatarsSrc = environment.appUrl + 'images/avatars/large/';
  user: any;

  editForm: FormGroup;

  constructor(
    private authService: AuthService,
    private router: Router,
    private snackBar: MatSnackBar,
    private titleService: Title,
    private snackbarService: SnackbarService
    ) { }

  ngOnInit() {
    this.titleService.setTitle('noedge :: profile');

    this.editForm = new FormGroup({
      name: new FormControl('', [ 
        Validators.required, 
        Validators.pattern("^[a-zA-Z]+$"),
        Validators.minLength(3) 
      ]),
      password: new FormControl('', [
        Validators.minLength(8),
        Validators.maxLength(8)
      ])
    });

    // this.authService.getUserData().subscribe(
    //   user => {
    //     this.user = user;
    //     this.editForm.get('name').setValue(this.user.name);
    //   }
    // );
  }

  logout() {
    this.authService.signout().then(
      () => {
        localStorage.removeItem("jwt:token");
        this.router.navigateByUrl('login');
      }
    );
  }

  clearControl(controlName: string) {
    this.editForm.get(controlName).setValue('');
  }

  updateUser() {
    var nameControl = this.editForm.get('name');
    if (nameControl.valid) {
      this.user.name = nameControl.value;
    }
    
    var passwordControl = this.editForm.get('password');

    // this.userService.update({ Name: nameControl.value, Password: passwordControl.value })
    //   .subscribe(
    //     () => {
    //       this.snackbarService.open("changes saved", true);
    //     }
    // );
  }

  cancelEdit() {
    this.mode = (this.mode === 'view') ? 'edit' : 'view';
    this.changeModeIcon = (this.mode === 'view') ? 'edit' : 'done';

    this.editForm.get('name').setValue(this.user.name);
    this.editForm.get('password').setValue(null);
    this.snackbarService.open("changes discarded", true);
  }

  changeMode() {
    if (this.mode == 'edit') { // unnec?
      this.updateUser();
    }
    this.mode = (this.mode === 'view') ? 'edit' : 'view';
    this.changeModeIcon = (this.mode === 'view') ? 'edit' : 'done';
  }
}