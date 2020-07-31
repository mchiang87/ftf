using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character {
    public int characterID;
    public string characterName;
    public string description;
    public bool isUnlocked;
    // public Sprite thumbnail;
    // public Sprite portrait;

    public Character(int characterID, string characterName, string description, bool isUnlocked) {
        this.characterID = characterID;
        this.characterName = characterName;
        this.description = description;
        this.isUnlocked = isUnlocked;
        // this.thumbnail = Resource.Load<Sprite>("Sprites/Characters/" + itemID);
        // this.portrait = Resource.Load<Sprite>("Portraits/Characters/" + itemID);
    }
}
