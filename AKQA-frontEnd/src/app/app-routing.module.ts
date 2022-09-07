import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ErrorComponent } from './component/error/error.component';
import { LoginComponent } from './component/login/login.component';
import { MainPageComponent } from './component/main-page/main-page.component';
import { RegisterComponent } from './component/register/register.component';
import { RecipeDetailsComponent } from './details/recipe-details/recipe-details.component';
import { UserDetailsComponent } from './details/user-details/user-details.component';

const routes: Routes = [
  {path:'', redirectTo: '/login', pathMatch:'full'},
  {path:'home', component: MainPageComponent},

  {path:'register', component: RegisterComponent},
  {path:'login', component:LoginComponent},

  {path:'profile/:Id', component:UserDetailsComponent},
  {path:'recipe/:Id', component:RecipeDetailsComponent},

  {path:'**', component:ErrorComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
