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
    originalSelectPos = new Vector3(selector.transform.position.x,selector.transform.position.y, 0f);
  }

  public void Update() {
    if(textItems.Any() && displayed == false) {
      displayed = true;
      SetItemDescription(0);
    };
    menuItemCount = textItems.Count();
    // Menu Navigation
    // if (EventSystem.current.currentSelectedGameObject.name == "InventoryTab") {
      // select down
      if (displayed == true) {
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
          if (menuItemIndex < menuItemCount - 1) {
            menuItemIndex++;
            Vector3 position = selector.transform.position;
            position.y -= yOffset;
            selector.transform.position = position;
            SetItemDescription(menuItemIndex);
          }
        }

        // select up
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
          if (menuItemIndex > 0) {
            menuItemIndex--;
            Vector3 position = selector.transform.position;
            position.y += yOffset;
            selector.transform.position = position;
            SetItemDescription(menuItemIndex);
          }
        }
      }
    // }
    //   if (Input.GetKeyDown(KeyCode.Space)) {
    //     // Select menu item and use for submenu if exist
    //   }
    // } else {
    //   menuItemIndex = 0;
    //   selector.transform.position = originalSelectPos;
    // }
  }

  // Creates a new text Entry
  public void CreateTextEntry(string newText, Color newColor, int id, int amount) {
    GameObject listItem = Instantiate(item) as GameObject;
    listItem.SetActive(true);
    listItem.GetComponent<ListText>().SetText(newText, newColor, id, amount);
    listItem.transform.SetParent(item.transform.parent, false);
    textItems.Add(listItem.gameObject);
  }

  public void RemoveTextEntry(int id) {

  }

  public void SetItemDescription(int index) {
    inventory = FindObjectOfType<Inventory>().inventory;
    itemDisplayed = inventory.Find(it => it.ID == textItems[index].GetComponent<ListText>().id);
    itemFlavorText.text = itemDisplayed.flavorText;
    itemDescription.text = itemDisplayed.description;
    // itemPortrait = itemDisplayed.sprite;
  }
}
