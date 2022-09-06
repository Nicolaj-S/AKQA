import { IRecipe } from "./IRecipe";

export interface IUser{
  Id : number;
  UserName: string;
  FirstName: string;
  LastName: string;
  Email: String;
  Password: string;
  Admin: boolean;
  IRecipe?: IRecipe[];
}

export interface LoggedInUser{
  UserName: string;
  Password:string
}
