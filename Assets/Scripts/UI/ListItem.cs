using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItem : MonoBehaviour {
  public void SetText(string myText, Color myColor) {
    GetComponent<Text>().text = myText;
    GetComponent<Text>().color = myColor;
  }
}
