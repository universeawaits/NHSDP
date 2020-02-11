import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CrudService {
  private entityClass: string;
  private searchUrl: string = environment.appUrl + 'api/' + this.entityClass;

  constructor(
    private httpClient: HttpClient
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
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token')} }
    );
    return result;
  }

  create(entity: any) {
    let result = new Observable<any>();
    result = this.httpClient.post(
      this.searchUrl,
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token')} }
    );
    return result;
  }  

  update(entity: any) {
    let result = new Observable<any>();
    result = this.httpClient.put(
      this.searchUrl,
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token')} }
    );
    return result;
  }  

  delete(entity: any) {
    let result = new Observable<any>();
    result = this.httpClient.delete(
      this.searchUrl,
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token')} }
    );
    return result;
  }  
}
