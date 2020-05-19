import { createStore, combineReducers } from 'redux';

interface IRootState {
  recipesState: IRecipesState;
} 

interface IRecipesState {
  recipes: IRecipe[]
}

interface IRecipe {
  ingredients: IIngredient[];
  summary: string;
}

interface IIngredient {
  name: string;
  measure: IIngredientMeasure;
  amount: number;
}

enum IIngredientMeasure {
  teaspoon,
  gram,
  piece
}

const initialState: IRecipesState = {
  recipes: []
}

interface IRecipeActionType {
  type: string;
  payload: IRecipe[];
}

const recipesReducer = (state = initialState, action: IRecipeActionType): IRecipesState => {
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

export const setupStore = () => {
  const combinedReducer = combineReducers<IRootState>(
    {
      recipesState: recipesReducer,
    }
  )
  return createStore(combinedReducer)
};