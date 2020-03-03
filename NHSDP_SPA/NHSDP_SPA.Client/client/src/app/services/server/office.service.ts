import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CrudService } from '../crud.service';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class UserService extends CrudService {
  constructor(
    httpClient: HttpClient, 
    authServie: AuthService) { 
    super(httpClient, authServie);
    this.entityClass = 'office';
  }
}
