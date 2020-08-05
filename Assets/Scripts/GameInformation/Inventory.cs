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
  }

  // Update is called once per frame
  void Update()
  {
    if (inventory.Any()) {
      Debug.Log(inventory[0]);
    }
  }

  #region Inventory
  public string AddItemToInventory(int id) {
    Item itemToAdd = itemDatabase.GetItem(id);
    inventory.Add(itemToAdd);
    inventoryListControl.CreateTextEntry(itemToAdd.itemName, Color.white, id);
    Debug.Log("added" + itemToAdd.itemName);
    return itemToAdd.description;
  }

  public void RemoveItemFromInventory(int id) {
    Item itemToRemove = CheckForItem(id);
    if (itemDatabase != null) {
      inventory.Remove(itemToRemove);
    }
    Debug.Log("removed" + itemToRemove.itemName);
  }

  public Item CheckForItem(int id) {
    return inventory.Find(item => item.itemID == id);
  }
#endregion
}
