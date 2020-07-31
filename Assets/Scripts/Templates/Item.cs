using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public int itemID;
    public string itemName;
    public string description;
    public int itemType;
    // public Sprite thumbnail;
    // public Sprite portrait;

    public Item(int itemID, string itemName, string description, int itemType) {
        this.itemID = itemID;
        this.itemName = itemName;
        this.description = description;
        // this.thumbnail = Resource.Load<Sprite>("Sprites/Items/" + itemID);
        // this.portrait = Resource.Load<Sprite>("Portraits/Items/" + itemID);
    }
}
