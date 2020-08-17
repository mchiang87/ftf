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
  public bool onMenuTab;
  private Animator anim;

  void Start() {
    menuTabs = new List<string> {
      "Party",
      "Inventory",
      "Recipes",
      "Journal",
      "Settings",
    };

    onMenuTab = true;
    menuTabCount = menuTabs.Count;
    anim = GetComponent<Animator>();
    originalSelectPos = new Vector3(selector.transform.position.x,selector.transform.position.y, 0f);
  }

  void Update() {
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
      
    } else if (!menuSwitch.showMenu) {
      menuTabIndex = 0;
      menuItemIndex = 0;
      onMenuTab = true;
      selector.transform.position = originalSelectPos;
      anim.Play("menu_party");
    }
  }
}
