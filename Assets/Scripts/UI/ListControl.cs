using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ListControl : MonoBehaviour {

  [SerializeField]
  public GameObject textTemplate;

  private List<GameObject> textItems;

  void start() {
    textItems = new List<GameObject>();
  }

  public void LogText(string newText, Color newColor) {

    if (textItems.Count == 10) {
      GameObject tempItem = textItems[0];
      Destroy(tempItem.gameObject);
      textItems.Remove(tempItem);
    }

    GameObject listItem = Instantiate(textTemplate) as GameObject;
    listItem.SetActive(true);

    listItem.GetComponent<ListItem>().SetText(newText, newColor);
    listItem.transform.SetParent(textTemplate.transform.parent, false);

    textItems.Add(listItem.gameObject);
  }

}
