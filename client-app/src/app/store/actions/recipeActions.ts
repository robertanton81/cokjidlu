import { IRecipe } from "../../models/Recipe";

export interface IRecipeInitActionType {
  type: string;
  payload: IRecipe[];
}