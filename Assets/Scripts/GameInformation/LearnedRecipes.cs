using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LearnedRecipes : MonoBehaviour {
  public List<Recipe> learnedRecipes;
  public RecipeDatabase recipeDatabase;
  private RecipeListControl recipeListControl;
  

  // Start is called before the first frame update
  void Start() {
    learnedRecipes = new List<Recipe>();
    recipeListControl = FindObjectOfType<RecipeListControl>();

    // once save inventory implemented, below makes more sense
    if (learnedRecipes.Any()) {
      for(int i = 0; i < learnedRecipes.Count; i++) {
        Debug.Log(learnedRecipes[i].name);
        recipeListControl.CreateTextEntry(learnedRecipes[i].name, Color.white, i, 1);
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
  }

  #region Inventory
  public string LearnRecipe(int id, int amount) {
    Recipe recipeToAdd = recipeDatabase.GetRecipe(id);
    learnedRecipes.Add(recipeToAdd);
    recipeListControl.CreateTextEntry(recipeToAdd.name, Color.white, id, amount);
    Debug.Log("added" + recipeToAdd.name);
    return recipeToAdd.flavorText;
  }
#endregion
}
