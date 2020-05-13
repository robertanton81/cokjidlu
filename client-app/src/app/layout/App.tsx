import React, { useState } from 'react';
import { IRecipe } from '../models/Recipe';
import axiosAgent from '../api/axiosAgent';

type IState = IRecipe[] | null;
const App: React.FC = () => {
  const [recipes, setRecipes] = useState<IState>(null);

  React.useEffect(() => {
    const recipeList = axiosAgent.Recipes.getList();
    recipeList.then(res => {
      setRecipes(res);
    });
  }, []);

  return (
    <div>
      {recipes &&
        <ul>
          {recipes.map(recipe => <li key={recipe.id}>{recipe.title}</li>)}
        </ul>}
    </div>
  );
};

export default App;
