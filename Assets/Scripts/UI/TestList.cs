using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestList : MonoBehaviour {
  [SerializeField]
  private string myText;
  [SerializeField]
  private Color myColor;
  [SerializeField]
  private ListControl logControl;

  public void LogText() {
    Debug.Log("preclick");
    logControl.LogText(myText, myColor);
    Debug.Log("clicked");
  }
}
