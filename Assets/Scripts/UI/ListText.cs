using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListText : MonoBehaviour {
  public int id;
  public int amount;

  public void SetText(string myText, Color myColor, int entryId, int amount = 0) {
    GetComponent<Text>().text = myText;
    GetComponent<Text>().color = myColor;
    id = entryId;
    amount = amount;
  }

    public void UpdateText(string myText, Color myColor) {
    GetComponent<Text>().text = myText;
    GetComponent<Text>().color = myColor;
  }
}
