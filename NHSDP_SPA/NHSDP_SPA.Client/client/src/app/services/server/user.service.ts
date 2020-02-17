import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { CrudService } from '../crud.service';

@Injectable({
  providedIn: 'root'
})
export class UserService extends CrudService {
  constructor(httpClient: HttpClient) { 
    super(httpClient);
    this.entityClass = 'my';
  }
}
