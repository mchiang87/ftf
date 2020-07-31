using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Will be called solely from the party submenu and tied to item database
public class Equip {
    public int equipID;
    public int itemID;
    // public Behavior behavior; // will need to plan/create/integrate equip modifiers with player mechanics
    // public Sprite thumbnail;
    // public Sprite portrait;

    public Equip(int equipID,int itemID) {
        this.equipID = equipID;
        this.itemID = itemID;
        // this.behavior = behavior;
        // this.thumbnail = Resource.Load<Sprite>("Sprites/Items/" + itemID);
        // this.portrait = Resource.Load<Sprite>("Portraits/Items/" + itemID);
    }
}
