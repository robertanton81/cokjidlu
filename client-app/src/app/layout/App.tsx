import React, { useState } from 'react';
import { IRecipe } from '../models/Recipe';
import axiosAgent from '../api/axiosAgent';
import styles from './App.module.css';
import Navbar from './Navbar/Navbar';

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
    <div className={styles.container}>
      <Navbar />
      {recipes &&
        <ul className={styles.list}>
          {recipes.map(recipe => <li key={recipe.id}>{recipe.title}</li>)}
        </ul>}
    </div>
  );
};

export default App;
