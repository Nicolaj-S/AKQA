import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { BehaviorSubject, empty, map, Observable } from 'rxjs';
import { IUser } from '../interface/IUser';
import { CreateUser } from '../interface/Create/ICreateUser';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})

export class UserService{
  private userSubject: BehaviorSubject<IUser>;
  public user: Observable<IUser>;

  constructor(private router: Router, private http:HttpClient){
    this.userSubject = new BehaviorSubject<IUser>(JSON.parse(localStorage.getItem('user')|| '{}'));
    this.user = this.userSubject.asObservable();
  }

  public get userValue(): IUser {
    return this.userSubject.value;
  }

  login(UserName: string, Password: string) {
    return this.http.post<IUser>(`${environment.urlLog}`, { UserName, Password })
        .pipe(map(user => {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('user', JSON.stringify(user));
            this.userSubject.next(user);
            return user;
        }));
  }
  logout() {
    // remove user from local storage and set current user to null
    localStorage.removeItem('user');
    this.router.navigate(['login']);
  }
  register(user: any) {
    return this.http.post(`${environment.urlReg}`, user);
  }
  GetUsers():Observable<IUser[]>{
    return this.http.get<IUser[]>(`${environment.apiUrl}User`);
  }
  GetUser(Id:number):Observable<IUser>{
    return this.http.get<IUser>(`${environment.apiUrl}User/${Id}`);
  }
  UpdateUser(Id:number,change:IUser){
    this.http.patch(`${environment.apiUrl}User/${Id}`, change).subscribe(res => {
      console.log("passed")
    }, error =>{
      console.log(error)
    });
  }
  DeleteUser(Id:number):Observable<IUser>{
    return this.http.delete<IUser>(`${environment.apiUrl}User/${Id}`)
  }
}
