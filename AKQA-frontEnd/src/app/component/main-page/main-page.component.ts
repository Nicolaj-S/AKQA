import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/service/user.service';
import { IUser } from 'src/app/interface/IUser';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'app-main-page',
  templateUrl: './main-page.component.html',
  styleUrls: ['./main-page.component.css']
})
export class MainPageComponent{

  User : IUser = JSON.parse(localStorage.getItem('user')|| '{}');
  constructor(private userService: UserService, private router: Router) {}

  ngOnInit(){
    this.userService.GetUser((this.User.id)).subscribe(Data => {this.User = Data; console.log(Data)})
    console.log(this.User)
  }

  GoToUserProfile(){
    this.router.navigate(['/profile/'])
  }
}
