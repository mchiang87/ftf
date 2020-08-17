using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDatabase : MonoBehaviour {
  public List<Recipe> recipes = new List<Recipe>();
  private void Awake() {
    BuildDatabase();
  }

  public Recipe GetRecipe(int id) {
    return recipes.Find(recipe => recipe.ID == id);
  }

  private void BuildDatabase() {
    recipes = new List<Recipe>() {
        new Recipe(0, "Roast", "A roast", 2.0f, 1,
          new List<int>() {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 14, 15}
        ),
        new Recipe(1, "Stew", "Stew", 1.5f, 1,
          new List<int>() {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 14, 15},
          new List<int>() {2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 14, 15}
        ),
        new Recipe(2, "Fruit Tart", "Fruit Tart", 1.0f, 2,
          new List<int>() {3},
          new List<int>() {16}
        ),
        new Recipe(3, "Biscuit", "A soft biscuit", 1.0f, 0,
          new List<int>() {16}
        ),
        new Recipe(4, "Rice and Beans", "Rice and Beans", 3.0f, 1,
          new List<int>() {4},
          new List<int>() {12}
        ),
        new Recipe(5, "Baked tuber", "A baked tuber", 1.0f, 0,
          new List<int>() {9}
        ),
        new Recipe(6, "Jambalaya", "Jambalaya", 5.0f, 1,
          new List<int>() {1, 4, 7, 9, 10, 13},
          new List<int>() {11},
          new List<int>() {21} // mirepoix
        ),
        new Recipe(7, "Mirepoix", "Mirepoix", 1.5f, 3,
          new List<int>() {2, 6, 14},
          new List<int>() {2, 6, 14},
          new List<int>() {20} // onion
        ),
    };
  }
}
