using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPC : Interactable {

  private DialogueManager dialogueManager;
  private bool interacted = false;
  protected SpriteRenderer spriteRenderer;
  public int itemID;

  protected void Start() {
    base.Start();
    dialogueManager = FindObjectOfType<DialogueManager>();
    spriteRenderer = GetComponent<SpriteRenderer>();
  }

  protected override void Interact() {
    if (!interacted) {
      if (!dialogueManager.dialogueActive) {
          dialogueManager.dialogueLines = new string[] {"Hi, I'm an NPC", "This is my second sentence!", "This third!"};;
          dialogueManager.currentLine = 0;
          dialogueManager.ShowDialogue();
      }
      interacted = true;
    } else {
      if (!dialogueManager.dialogueActive) {
          dialogueManager.dialogueLines = new string[] {"You know me", "We talked already!"};;
          dialogueManager.currentLine = 0;
          dialogueManager.ShowDialogue();
      }
    }
    transform.GetComponent<NPC>().canMove = false;
  }
}
