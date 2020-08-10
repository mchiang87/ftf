using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour {
  public List<Item> items = new List<Item>();
  private void Awake() {
    BuildDatabase();
  }

  public Item GetItem(int id) {
    return items.Find(item => item.itemID == id);
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
        new Item(2, "Carobit Meat", "Meat from a carobit", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Carrot", "A carrot", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Strawberry", "A strawberry", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Long Bean", "A long bean", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Khojit Meat", "Meat from a khojit", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Peppercorns", "Some peppercorns", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Tubor Meat", "Meat from a tubor", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Tuber", "A tuber", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Mushroom", "A mushroom", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Fowlbeast Meat", "Meat from a fowlbeast", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Rice Grains", "Some grains of rice", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Carobit Meat", "Meat from a carobit", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Sugarcane", "A sugarcane", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Celobit Meat", "Meat from a celobit", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
        new Item(2, "Celery", "A celery", 0, "Used for cooking",
          new Dictionary<string, int> {
            { "Marks", 10 }
          }
        ),
    };
  }
}
