using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryListControl : MonoBehaviour {

  [SerializeField]
  private GameObject item;
  // private Inventory inventory;
  private List<Item> inventory;

  private List<GameObject> textItems;

  public void Start() {
    textItems = new List<GameObject>();
    inventory = FindObjectOfType<Inventory>().inventory;
    for(int i = 0; i < inventory.Count; i++) {
      Debug.Log(inventory[i].itemName);
      CreateTextEntry(inventory[i].itemName, Color.white, inventory[i].itemID);
    }
  }

  // Creates a new text Entry
  public void CreateTextEntry(string newText, Color newColor, int id) {
    GameObject listItem = Instantiate(item) as GameObject;
    listItem.SetActive(true);
    listItem.GetComponent<ListText>().SetText(newText, newColor, id);
    listItem.transform.SetParent(item.transform.parent, false);
    textItems.Add(listItem.gameObject);
  }

  public void RemoveTextEntry(int id) {
    
  }
}
