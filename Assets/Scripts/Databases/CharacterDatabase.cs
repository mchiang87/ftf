using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDatabase : MonoBehaviour
{
    public List<Character> characters = new List<Character>();
    private void Awake() {
        BuildDatabase();
        Debug.Log("Character Database Awakening");
    }

    public Character GetCharacter(int id) {
        return characters.Find(character => character.characterID == id);
    }

    private void BuildDatabase() {
        characters = new List<Character>() {
            new Character(0, "Robin", "Main character", true),
            new Character(1, "Sam", "First character met", false),
        };
        Debug.Log(characters);
    }

}
