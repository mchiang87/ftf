﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe {
    public int recipeID;
    public string recipeName;
    public string description;
    public List<int> ingredients;
    public int itemToCraft;
    // public Sprite portrait;
    // public int itemID; will be used to reference recipe's dish portrait

    public Recipe(int recipeID, string recipeName, string description, List<int> ingredients, int itemToCraft) {
        this.recipeID = recipeID;
        this.recipeName = recipeName;
        this.description = description;
        this.ingredients = ingredients;
        this.itemToCraft = itemToCraft;
        // this.portrait = Resource.Load<Sprite>("Portraits/Items/" + itemID);
    }
}
