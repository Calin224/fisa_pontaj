import {inject, Injectable, signal} from '@angular/core';
import {HttpClient, HttpParams} from '@angular/common/http';
import {User} from '../../shared/models/user';
import {map, tap} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = "https://localhost:5001/api/";
  http = inject(HttpClient);
  currentUser = signal<User | null>(null);


  login(values: any){
    let params = new HttpParams();
    params = params.append('useCookies', true);

    return this.http.post<User>(this.baseUrl + 'login', values, {params, withCredentials: true}).pipe(
      tap((user: User) => {
        localStorage.setItem('userId', user.id);
      })
    )
  }

  getUserInfo(){
    return this.http.get<User>(this.baseUrl + 'account/user-info', {withCredentials: true}).pipe(
      map(user => {
        this.currentUser.set(user);
        return user;
      })
    )
  }

  logout(){
    return this.http.post(this.baseUrl + 'account/logout', {}, {withCredentials: true});
  }

  register(values: any){
    return this.http.post(this.baseUrl + 'account/register', values);
  }
}
