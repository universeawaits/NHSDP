import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CrudService } from '../crud.service';
import { AuthService } from 'src/app/core/authentication/auth.service';

@Injectable({
  providedIn: 'root'
})
export class OfficeService extends CrudService {
  constructor(
    httpClient: HttpClient, 
    authServie: AuthService) { 
    super(httpClient, authServie);
    this.entityClass = 'office';
  }
}
