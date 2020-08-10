using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Will be called solely from the party submenu and tied to item database
public class Dish {
    public int dishID;
    public int itemID;
    // public Behavior behavior; // will need to plan/create/integrate equip modifiers with player mechanics
    // public Sprite thumbnail;
    // public Sprite portrait;

    public Dish(int dishID,int itemID) {
        this.dishID = dishID;
        this.itemID = itemID;
        // this.behavior = behavior;
        // this.thumbnail = Resource.Load<Sprite>("Sprites/Items/" + itemID);
        // this.portrait = Resource.Load<Sprite>("Portraits/Items/" + itemID);
    }
}
