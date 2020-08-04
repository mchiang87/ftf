using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SubMenuSelector : MonoBehaviour {
  private int menuItemIndex;
  private int menuItemCount;
  public Vector3 originalSelectPos;
  public GameObject selector;
  public float yOffset;
  public float xOffset;
  private Inventory inventory;

  // Start is called before the first frame update
  void Start() {
    menuItemCount = FindObjectOfType<Inventory>().inventory.Count;
    // menuItemCount = GameManager.instance.inventory.Count;
    originalSelectPos = new Vector3(selector.transform.position.x,selector.transform.position.y, 0f);
  }

  // Update is called once per frame
  void Update() {
    // Menu Navigation
    if (EventSystem.current.currentSelectedGameObject.name == "Inventory Tab") {
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
      menuItemIndex = 0;
      selector.transform.position = originalSelectPos;
    }
  }
}
