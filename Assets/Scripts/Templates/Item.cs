using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public int itemID;
    public string itemName;
    public string flavorText;
    public int itemType;
    public string description;
    public Dictionary<string, int> stats = new Dictionary<string, int>();
    // public Sprite thumbnail;
    // public Sprite portrait;

    public Item(int itemID, string itemName, string flavorText, int itemType, string description, Dictionary<string, int> stats) {
        this.itemID = itemID;
        this.itemName = itemName;
        this.flavorText = flavorText;
        this.itemType = itemType;
        this.description = description;
        this.stats = stats;
        // this.thumbnail = Resource.Load<Sprite>("Sprites/Items/" + itemID);
        // this.portrait = Resource.Load<Sprite>("Portraits/Items/" + itemID);
    }
}
