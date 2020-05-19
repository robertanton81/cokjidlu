import { IRecipe } from "../../models/Recipe";
import { IRecipeInitActionType } from "../actions/recipeActions";

export interface IRecipesState {
  recipes: IRecipe[]
}

const initialState: IRecipesState = {
  recipes: []
}

export const recipesReducer = (state = initialState, action: IRecipeInitActionType): IRecipesState => {
  switch (action.type) {
    case 'INIT_RECIPES':
      const { payload } = action
      return {
        ...state,
        recipes: payload
      }
  
    default:
      return state;
  }
}