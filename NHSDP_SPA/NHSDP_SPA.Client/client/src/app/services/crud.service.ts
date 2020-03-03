import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AuthService } from './server/auth.service';

@Injectable({
  providedIn: 'root'
})
export class CrudService {
  public set entityClass(value: string) {
    this._entityClass = value;
    this.searchUrl = environment.appUrl + this._entityClass
  }

  private _entityClass: string;
  private searchUrl: string;

  constructor(
    private httpClient: HttpClient,
    private authService: AuthService
    ) { }

  get(id: string) {
    let result = new Observable<any>();
    result = this.httpClient.get(
      this.searchUrl + '?id=' + id,
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token')} }
    );
    return result;
  }

  getAll() {
    let result = new Observable<any>();
    result = this.httpClient.get(
      this.searchUrl,
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token') } }
    );
    return result;
  }

  create(entity: any) {
    let result = new Observable<any>();
    result = this.httpClient.post(
      this.searchUrl, entity,
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token') }, responseType: 'text' }
    ); 
    return result;
  }  

  update(entity: any) {
    let result = new Observable<any>();
    result = this.httpClient.put(
      this.searchUrl, entity,
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token') }, responseType: 'text' }
    );
    return result;
  }  

  delete(id: any) {
    let result = new Observable<any>();
    result = this.httpClient.delete(
      this.searchUrl + '?id=' + id,
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token') } }
    );
    return result;
  }

  getHttpOptions() {
    return {
      headers: new HttpHeaders({
        'Content-Type':  'application/json',
        'Authorization': this.authService.authorizationHeaderValue
      })
    };
  }
}
