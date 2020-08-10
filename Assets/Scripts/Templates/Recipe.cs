using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recipe {
    public int ID;
    public string name;
    public string flavorText;
    public float multiplier;
    public List<int> firstSlotIngredient;
    public List<int> secondSlotIngredient;
    public List<int> thirdSlotIngredient;
    // public Sprite portrait;
    // public int itemID; will be used to reference recipe's dish portrait

    public Recipe(int ID, string name, string flavorText, float multiplier, List<int> firstSlotIngredient, List<int> secondSlotIngredient = null, List<int> thirdSlotIngredient = null) {
        this.ID = ID;
        this.name = name;
        this.flavorText = flavorText;
        this.multiplier = multiplier;
        this.firstSlotIngredient = firstSlotIngredient;
        this.secondSlotIngredient = secondSlotIngredient;
        this.thirdSlotIngredient = thirdSlotIngredient;
        // this.portrait = Resource.Load<Sprite>("Portraits/Items/" + itemID);
    }
}
