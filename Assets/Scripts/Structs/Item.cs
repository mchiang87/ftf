using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public int itemID;
    public string itemName;
    public string description;
    // public Sprite sprite;

    public Item(int itemID, string itemName, string description) {
        this.itemID = itemID;
        this.itemName = itemName;
        this.description = description;
        // this.icon = Resource.Load<Sprite>("Sprites/Items/" + itemName);
    }
}
