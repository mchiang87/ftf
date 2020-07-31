using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe {
    public int recipeID;
    public string recipeName;
    public string description;
    public List<int> ingredients;
    // public Sprite portrait;
    // public int itemID; will be used to reference recipe's dish portrait

    public Recipe(int recipeID, string recipeName, string description, List<int> ingredients) {
        this.recipeID = recipeID;
        this.recipeName = recipeName;
        this.description = description;
        this.ingredients = ingredients;
        // this.portrait = Resource.Load<Sprite>("Sprites/Items/" + itemID);
    }
}
