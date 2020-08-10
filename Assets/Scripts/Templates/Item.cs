using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {
    public int ID;
    public string name;
    public string flavorText;
    public int type;
    public string description;
    public Dictionary<string, int> stats = new Dictionary<string, int>();
    // public Sprite thumbnail;
    // public Sprite portrait;

    public Item(int ID, string name, string flavorText, int type, string description, Dictionary<string, int> stats) {
        this.ID = ID;
        this.name = name;
        this.flavorText = flavorText;
        this.type = type;
        this.description = description;
        this.stats = stats;
        // this.thumbnail = Resource.Load<Sprite>("Sprites/Items/" + itemID);
        // this.portrait = Resource.Load<Sprite>("Portraits/Items/" + itemID);
    }
}
