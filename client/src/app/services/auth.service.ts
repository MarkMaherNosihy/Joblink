import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { AuthUser } from '../models/AuthUser';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private httpClient = inject(HttpClient);
  private baseUrl: string = 'https://localhost:5000/api/';
  private isLoggedIn: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  currentUser = signal<AuthUser | null>(null);


  login(model:any){
    return this.httpClient.post<AuthUser>(this.baseUrl + 'accounts/login', model).pipe(
      map(user=> {
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
      })
    );
  }

  register(model:any){
    return this.httpClient.post<AuthUser>(this.baseUrl + 'accounts/register', model).pipe(
      map(user=> {
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUser.set(user);
        }
        return user;
      })
    );
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUser.set(null);
  }
  setIsLoggedIn(value:boolean){
    this.isLoggedIn.next(value);
  }
  getIsLoggedIn(){
    return this.isLoggedIn.asObservable();
  }
}
