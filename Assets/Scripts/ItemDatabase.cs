using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    private void Awake() {
        BuildDatabase();
        Debug.Log("Database Awakening");
    }

    public Item GetItem(int id) {
        return items.Find(item => item.itemID == id);
    }

    private void BuildDatabase() {
        items = new List<Item>() {
            new Item(0, "Gem", "A sparkly gem"),
            new Item(1, "Heart", "A hearth"),
        };
        Debug.Log(items);
    }

}
