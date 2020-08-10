using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour {
  public List<Item> inventory;
  public ItemDatabase itemDatabase;
  private InventoryListControl inventoryListControl;
  

  // Start is called before the first frame update
  void Start() {
    inventory = new List<Item>();
    inventoryListControl = FindObjectOfType<InventoryListControl>();

    // once save inventory implemented, below makes more sense
    if (inventory.Any()) {
      for(int i = 0; i < inventory.Count; i++) {
        Debug.Log(inventory[i].name);
        inventoryListControl.CreateTextEntry(inventory[i].name, Color.white, i, 1);
      }
    }
  }

  // Update is called once per frame
  void Update()
  {
  }

  #region Inventory
  public string AddItemToInventory(int id, int amount) {
    Item itemToAdd = itemDatabase.GetItem(id);
    inventory.Add(itemToAdd);
    inventoryListControl.CreateTextEntry(itemToAdd.name, Color.white, id, amount);
    Debug.Log("added" + itemToAdd.name);
    return itemToAdd.description;
  }

  public void RemoveItemFromInventory(int id) {
    Item itemToRemove = CheckForItem(id);
    if (itemDatabase != null) {
      inventory.Remove(itemToRemove);
    }
    Debug.Log("removed" + itemToRemove.name);
  }

  public Item CheckForItem(int id) {
    return inventory.Find(item => item.ID == id);
  }
#endregion
}
