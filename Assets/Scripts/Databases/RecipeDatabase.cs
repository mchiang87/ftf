using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabase : MonoBehaviour {
  public List<Recipe> recipes = new List<Recipe>();
  private void Awake() {
    BuildDatabase();
  }

  public Recipe GetRecipe(int id) {
    return recipes.Find(recipe => recipe.recipeID == id);
  }

  private void BuildDatabase() {
    recipes = new List<Recipe>() {
        new Recipe(0, "Biscuit", "A soft biscuit", new List<int>() {0, 1}, 3),
        new Recipe(1, "Scrambled Eggs", "Scrambled Eggs", new List<int>() {0, 1}, 4),
    };
  }
}
