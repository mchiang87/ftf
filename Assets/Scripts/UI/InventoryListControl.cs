using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryListControl : MonoBehaviour {

  [SerializeField]
  private GameObject item;

  private List<GameObject> textItems;
  private List<Item> inventory;

  public void Start() {
    textItems = new List<GameObject>();
    inventory = GameManager.instance.inventory;
  }

  public void Update() {
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

}
