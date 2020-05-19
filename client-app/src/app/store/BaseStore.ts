import { createStore, combineReducers } from 'redux';
import { recipesReducer, IRecipesState } from './reducers/recipeReducer';

interface IRootState {
  recipesState: IRecipesState;
} 


export const setupStore = () => {
  const combinedReducer = combineReducers<IRootState>(
    {
      recipesState: recipesReducer,
    }
  )
  return createStore(combinedReducer)
};