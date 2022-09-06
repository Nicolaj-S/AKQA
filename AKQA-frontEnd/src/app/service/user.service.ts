import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { IUser, LoggedInUser } from '../interface/IUser';
import { CreateUser } from '../interface/Create/ICreateUser';

@Injectable({
  providedIn: 'root'
})

export class UserService{
  public apiUrl = "https://localhost:7254/api/User"
  url : string = "https://localhost:7254/api/"

  constructor(private http:HttpClient){}

  GetUsers():Observable<IUser[]>{
    return this.http.get<IUser[]>(this.apiUrl);
  }
  GetUser(Id:number):Observable<IUser>{
    return this.http.get<IUser>(`${this.apiUrl}User/${Id}`);
  }

  Create(data: any):Observable<CreateUser>{
    return this.http.post<CreateUser>(`${this.url}User`,data);
  }
  UpdateUser(Id:number,change:IUser){
    this.http.patch(`${this.url}User/${Id}`, change).subscribe(res => {
      console.log("passed")
    }, error =>{
      console.log(error)
    });
  }
  DeleteUser(Id:number):Observable<IUser>{
    return this.http.delete<IUser>(`${this.url}User/${Id}`)
  }

  Login():Observable<LoggedInUser>{
    return
  }
}
