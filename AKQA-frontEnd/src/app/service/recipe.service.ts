import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { IRecipe } from '../interface/IRecipe';
import { CreateRecipe } from '../interface/Create/ICreateRecipe';

@Injectable({
  providedIn: 'root'
})

export class RecipeService{
  public apiUrl = "https://localhost:7254/api/Recipe"
  url: string = "https://localhost:7254/api/Recipe"
  constructor(private http:HttpClient){}

  GetRecipes():Observable<IRecipe[]>{
    return this.http.get<IRecipe[]>(this.apiUrl);
  }
  GetRecipe():Observable<IRecipe>{
    return this.http.get<IRecipe>(this.apiUrl);
  }

  Create(data: any):Observable<CreateRecipe>{
    return this.http.post<CreateRecipe>(`${this.url}`,data);
  }
  UpdateRecipe(Id:number,change:IRecipe){
    this.http.patch(`${this.url}${Id}`, change).subscribe(res => {
      console.log("passed")
    }, error =>{
      console.log(error)
    });
  }
  DeleteRecipe(Id:number):Observable<IRecipe>{
    return this.http.delete<IRecipe>(`${this.url}${Id}`)
  }
}
