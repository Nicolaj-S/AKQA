import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/service/user.service';
import { IUser } from 'src/app/interface/IUser';

@Component({
  selector: 'app-user-details',
  templateUrl: './user-details.component.html',
  styleUrls: ['./user-details.component.css']
})
export class UserDetailsComponent implements OnInit {

  User : IUser = JSON.parse(localStorage.getItem('user')|| '{}');;


  constructor(private userService: UserService, private route: ActivatedRoute, private router:Router) {
  }

  ngOnInit(){

  }

}
