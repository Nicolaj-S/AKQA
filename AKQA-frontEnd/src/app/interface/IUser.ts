import { IRecipe } from "./IRecipe";

export interface IUser{
  id : number;
  userName: string;
  firstName: string;
  lastName: string;
  password: string;
  admin: boolean;
  IRecipe?: IRecipe[];
  token: string;
}

