using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItem : Interactable {

  private DialogueManager dialogueManager;
  private bool interacted = false;
  private string item;
  protected SpriteRenderer spriteRenderer;
  public Sprite afterInteract;
  public int itemID;

  protected void Start() {
    base.Start();
    dialogueManager = FindObjectOfType<DialogueManager>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    item = "";
  }

  protected override void Interact() {
    if (!interacted) {
      spriteRenderer.sprite = afterInteract;
      item = GameManager.instance.AddItemToInventory(itemID);
      if (!dialogueManager.dialogueActive) {
        dialogueManager.dialogueLines = new string[] {"You received " + item + "!", "Testing second line!"};
        dialogueManager.currentLine = 0;
        dialogueManager.ShowDialogue();
      }
      interacted = true;
    } else {
      if (afterInteract == null) {
          Destroy(gameObject);
      }
    }
  }
}
