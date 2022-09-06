import { IRecipe } from "./IRecipe";

export interface IUser{
  Id : number;
  UserName: string;
  FirstName: string;
  LastName: string;
  Password: string;
  Admin: boolean;
  IRecipe?: IRecipe[];
  token: string;
}

