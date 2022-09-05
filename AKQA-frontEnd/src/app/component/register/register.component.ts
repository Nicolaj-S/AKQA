import { Component, OnInit, SimpleChange } from '@angular/core';
import { FormArray, FormControl,FormBuilder, FormGroup, ReactiveFormsModule } from '@angular/forms';

import { CreateUser } from 'src/app/interface/Create/ICreateUser';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent{

  public url = "https://localhost:7254/api/User/"

  UserCreate = new FormGroup({
    UserName : new FormControl(''),
    FirstName : new FormControl(''),
    LastName : new FormControl(''),
    Email : new FormControl(''),
    Password : new FormControl(''),
  })

  constructor(
    private UserService : UserService
  ) { }

  ngOnInit(){
    this.UserCreate;
  }

  Create(UserName: string, FirstName: string, LastName: string, Email: string, Password: string){

    let Data = {
      UserName: UserName,
      FirstName: FirstName,
      LastName: LastName,
      Email: Email,
      Password: Password,
    }
    this.UserService.Create(Data).subscribe(Data => {
      console.log(Data)
      this.ngOnInit()
    }, (error:any) =>{
      console.log(error)
    })
  }

}
