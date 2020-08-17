using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour {
  public int menuTabIndex;
  public int menuItemIndex;
  public Vector3 originalSelectPos;
  public MenuSwitch menuSwitch;
  public GameObject selector;
  public float yOffset;
  public float xOffset;

  public List<string> menuTabs; // Change from string to menu class?
  private List<List<string>> menuItems; // Change from string to menu class?
  private int menuTabCount;
  private int menuItemCount;
  private int currentCharacterSelection = 0;
  private bool onMenuTab;
  private Animator anim;

  void Start() {
    menuTabs = new List<string> {
      "Party",
      "Inventory",
      "Recipes",
      "Journal",
      "Settings",
    };

    menuItems = new List<List<string>> {
      // Party Menu Items
      new List<string> {
        // Party Menu SubItems
        "Equip1",
        "Equip2",
        "Equip3",
      },
      // Inventory Menu Items
      new List<string> {
        // Inventory Menu Sub Items
        "Inv1"
      },
      // Recipes Menu Items
      new List<string> {
        // Recipes Menu Sub Items
        "Rec1"
      },
      // Journal Menu Items
      new List<string> {
        // Journal Menu Sub Items
        "Jour1"
      },
      // Settings Menu Items
      new List<string> {
        // Settings Menu Sub Item
        "Set1"
      },
    };
    onMenuTab = true;
    menuTabCount = menuTabs.Count;
    menuItemCount = menuItems.Count;
    anim = GetComponent<Animator>();
    originalSelectPos = new Vector3(selector.transform.position.x,selector.transform.position.y, 0f);
  }

  void Update() {
    // Menu updates
    // if (menuTabIndex = menuTabs[])

    // Menu Navigation
    if (menuSwitch.showMenu && onMenuTab) {
      // select right
      if (Input.GetKeyDown(KeyCode.RightArrow)) {
        if (menuTabIndex < menuTabCount - 1) {
          menuTabIndex++;
          Vector3 position = selector.transform.position;
          position.x += xOffset;
          selector.transform.position = position;
          anim.SetTrigger("ShowNext");
          Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        }
      }

      // select left
      if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        if (menuTabIndex > 0) {
          menuTabIndex--;
          Vector3 position = selector.transform.position;
          position.x -= xOffset;
          selector.transform.position = position;
          anim.SetTrigger("ShowPrevious");
          Debug.Log(EventSystem.current.currentSelectedGameObject.name);
        }
      }

      if (Input.GetKeyDown(KeyCode.Space)) {
        // relinquish control to individual menu controls
        onMenuTab = false;
      }
    } else {
      menuTabIndex = 0;
      menuItemIndex = 0;
      selector.transform.position = originalSelectPos;
      anim.Play("menu_party");
    }
  }
}
