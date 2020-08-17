using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSwitch : MonoBehaviour {
  // Logic 
  private Animator anim;
  public bool showMenu;

  public Button party;

  public void Start() {
    anim = GetComponent<Animator>();
    showMenu = false;
  }

  public void Update() {
    if (Input.GetKeyDown(KeyCode.Tab)) {
      Time.timeScale = Convert.ToSingle(showMenu);
      showMenu = !showMenu;
      party.Select();
      anim.SetBool("ShowMenu", showMenu);
    }
  }
}
