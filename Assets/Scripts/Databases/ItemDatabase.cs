using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
  public List<Item> items = new List<Item>();
  private void Awake() {
    BuildDatabase();
  }

  public Item GetItem(int id) {
    return items.Find(item => item.ID == id);
  }

  private void BuildDatabase() {
    items = new List<Item>() {
        new Item(0, "Gem", "A sparkly gem", 0, "Sell for marks",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(1, "Heart", "A hearth", 0, "Heals player",
          new Dictionary<string, int> {
            { "Heal", 5 }
          }
        ),
        new Item(2, "Carobit Meat", "Meat from a carobit", 1, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(3, "Carrot", "A carrot", 2, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(4, "Strawberry", "A strawberry", 3, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(5, "Long Bean", "A long bean", 2, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(6, "Khojit Meat", "Meat from a khojit", 1, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(7, "Bell Pepper", "A bell pepper", 2, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(8, "Tubor Meat", "Meat from a tubor", 1, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(9, "Tuber", "A tuber", 2, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(10, "Mushroom", "A mushroom", 2, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(11, "Fowlbeast Meat", "Meat from a fowlbeast", 1, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(12, "Rice Grains", "Some grains of rice", 4, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(13, "Sugarcane", "A sugarcane", 3, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(14, "Celobit Meat", "Meat from a celobit", 1, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(15, "Celery", "A celery", 2, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(16, "Flour", "Flour", 4, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),        
    };
  }
}
