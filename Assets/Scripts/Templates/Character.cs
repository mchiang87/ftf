using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
    public int characterID;
    public string characterName;
    public string description;
    // public Sprite thumbnail;
    // public Sprite portrait;

    public Character(int characterID, string characterName, string description) {
        this.characterID = characterID;
        this.characterName = characterName;
        this.description = description;
        // this.thumbnail = Resource.Load<Sprite>("Sprites/Characters/" + itemID);
        // this.portrait = Resource.Load<Sprite>("Portraits/Characters/" + itemID);
    }
}
