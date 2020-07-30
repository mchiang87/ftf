using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationSelect : MonoBehaviour
{
    private int menuTabIndex = 0;
    private int menuItemIndex = 0;
    // Right/Left selection only to tab between menu parts
    private int menuTabs = 5;
    // Up/Down selection only to interact within menu
    private int menuItems;
    private int subMenuItems;
    public float yOffset;
    public float xOffset;

    void Start()
    {
        
    }

    void Update() {
        // select right
      if (Input.GetKeyDown(KeyCode.RightArrow)) {
        if (menuTabIndex < menuTabs - 1) {
          menuTabIndex++;
          Vector3 position = transform.position;
          position.x += xOffset;
          transform.position = position;
        }
      }

      // select left
      if (Input.GetKeyDown(KeyCode.LeftArrow)) {
        if (menuTabIndex > 0) {
          menuTabIndex--;
          Vector3 position = transform.position;
          position.x -= xOffset;
          transform.position = position;
        }
      }

      // select down
      if (Input.GetKeyDown(KeyCode.DownArrow)) {
        if (menuItemIndex <= menuItems - 1) {
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
    }
}
