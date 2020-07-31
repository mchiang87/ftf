using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuManager : MonoBehaviour {
  public int menuTabIndex;
  public int menuItemIndex;
  public Vector3 originalSelectPos;
  public Animator anim;
  public CharacterMenu characterMenu; // remove once merge this file with charactermenu file
  public GameObject selector;
  public float yOffset;
  public float xOffset;

  private List<string> menuTabs; // Change from string to menu class?
  private List<List<string>> menuItems; // Change from string to menu class?
  private int menuTabCount;
  private int menuItemCount;
  private int currentCharacterSelection = 0;
  private bool onMenuTab;

    // Start is called before the first frame update
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

  // Update is called once per frame
  void Update() {
    // Menu updates
    // if (menuTabIndex = menuTabs[])

    // Menu Navigation
    if (characterMenu.showMenu) {
      if (Input.GetKeyDown(KeyCode.RightArrow)) {
        if (menuTabIndex < menuTabCount - 1) {
          menuTabIndex++;
          Vector3 position = selector.transform.position;
          position.x += xOffset;
          selector.transform.position = position;
          anim.SetTrigger("ShowNext");
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
        }
      }

      // select down
      if (Input.GetKeyDown(KeyCode.DownArrow)) {
        if (menuItemIndex <= menuItemCount - 1) {
          menuItemIndex++;
          Vector3 position = transform.position;
          position.y += yOffset;
          transform.position = position;
        }
      }

      // select up
      if (Input.GetKeyDown(KeyCode.UpArrow)) {
        if (menuItemIndex > 0) {
          menuItemIndex--;
          Vector3 position = transform.position;
          position.y -= yOffset;
          transform.position = position;
        }
      }

      if (Input.GetKeyDown(KeyCode.Space)) {
        // Select menu item and use for submenu if exist
      }
    } else {
      menuTabIndex = 0;
      menuItemIndex = 0;
      selector.transform.position = originalSelectPos;
      anim.Play("menu_party");
    }
  }
}
