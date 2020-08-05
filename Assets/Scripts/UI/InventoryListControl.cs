using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryListControl : MonoBehaviour {

  [SerializeField]
  private GameObject item;
  // private Inventory inventory;
  private List<Item> inventory;
  private Item itemDisplayed;
  private List<GameObject> textItems;
  private bool displayed;
  // public Sprite itemPortrait;
  public Text itemFlavorText;
  public Text itemDescription;
  public GameObject selector;
  public float yOffset;
  public Vector3 originalSelectPos;
  public int menuItemIndex;
  private int menuItemCount;
  public void Start() {
    displayed = false;
    textItems = new List<GameObject>();
    inventory = FindObjectOfType<Inventory>().inventory;
    if (inventory != null) {
      for(int i = 0; i < inventory.Count; i++) {
        Debug.Log(inventory[i].itemName);
        CreateTextEntry(inventory[i].itemName, Color.white, inventory[i].itemID);
      }
    }
    Debug.Log(inventory);
  }

  public void Update() {
    if(textItems.Any()) {
      displayed = true;
      Debug.Log(inventory);
      // itemDisplayed = inventory.Find(it => it.itemID == textItems[0].GetComponent<ListText>().id);
      // // itemPortrait = itemDisplayed.sprite;
      // itemFlavorText.text = itemDisplayed.flavorText;
      // itemDescription.text = itemDisplayed.description;
    };
    // menuItemCount = textItems.Count();
    // // Menu Navigation
    // if (EventSystem.current.currentSelectedGameObject.name == "Inventory") {
    //   // select down
    //   if (Input.GetKeyDown(KeyCode.DownArrow)) {
    //     if (menuItemIndex <= menuItemCount - 1) {
    //       menuItemIndex++;
    //       Vector3 position = transform.position;
    //       position.y += yOffset;
    //       transform.position = position;
    //     }
    //   }

    //   // select up
    //   if (Input.GetKeyDown(KeyCode.UpArrow)) {
    //     if (menuItemIndex > 0) {
    //       menuItemIndex--;
    //       Vector3 position = transform.position;
    //       position.y -= yOffset;
    //       transform.position = position;
    //     }
    //   }

    //   if (Input.GetKeyDown(KeyCode.Space)) {
    //     // Select menu item and use for submenu if exist
    //   }
    // } else {
    //   menuItemIndex = 0;
    //   selector.transform.position = originalSelectPos;
    // }
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
