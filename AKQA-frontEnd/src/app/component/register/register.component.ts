import { Component, OnInit, SimpleChange } from '@angular/core';
import { FormArray, FormControl,FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs';

import { CreateUser } from 'src/app/interface/Create/ICreateUser';
import { IUser } from 'src/app/interface/IUser';
import { UserService } from 'src/app/service/user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent{
  form: FormGroup;
  loading = false;
  submitted = false;

  constructor( private formbuilder: FormBuilder, private UserService: UserService, private router: Router, private route: ActivatedRoute) {
    this.form = this.formbuilder.group({
      username: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      password: ['', Validators.required]
    })
   }

  ngOnInit(){
  }

  get f() { return this.form.controls; }

  onSubmit(){
    this.submitted = true;

    if(this.form.invalid)
      return;

    let Data = {
      UserName: this.f['username'].value,
      FirstName: this.f['firstName'].value,
      LastName: this.f['lastName'].value,
      Password: this.f['password'].value
    }
    this.loading = true
    this.UserService.register(Data)
      .pipe(first()).subscribe({next: () =>{
        const returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/login';
        this.router.navigateByUrl(returnUrl);
      },
      error: error=> {
        console.error(error.message);
        this.loading = false
      }
    });
  }
}
