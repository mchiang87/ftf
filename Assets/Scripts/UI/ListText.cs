using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListText : MonoBehaviour {
  public int id;

  public void SetText(string myText, Color myColor, int entryId) {
    GetComponent<Text>().text = myText;
    GetComponent<Text>().color = myColor;
    id = entryId;
  }
}
