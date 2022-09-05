import { IUser } from "./IUser";

export interface IRecipe{
  Id: number;
  RecipeName: string;
  RecipeImage: string;
  Description: string;
  IUser?: IUser[];
}
