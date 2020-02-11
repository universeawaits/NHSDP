import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private hostUrl: string = environment.appUrl + 'my';

  constructor(
    private httpClient: HttpClient
    ) { }

  login(name: string, password: string): Observable<any> {
    let user = { Name: name, Password: password };
    return this.httpClient.post(this.hostUrl + '/token', user, { headers: { 'No-Auth' : 'True' }});
  }

  getUserData() {
    let result = new Observable<any>();
    result = this.httpClient.get<any>(
      this.hostUrl,
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token')} }
    );
    return result;
  }

  logout(): Observable<any> {
    return this.httpClient.post(
      this.hostUrl + '/logout', 
      null, 
      { headers: { 'Authorization' : 'Bearer ' + localStorage.getItem('jwt:token')}});
  }
}
