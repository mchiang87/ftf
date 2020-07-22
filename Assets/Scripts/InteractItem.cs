using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractItem : Interactable {

    private DialogueManager dialogueManager;
    private bool interacted = false;
    protected SpriteRenderer spriteRenderer;
    public Sprite afterInteract;
    public int itemID;

    protected void Start() {
        base.Start();
        dialogueManager = FindObjectOfType<DialogueManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Interact() {
        if (!interacted) {
            spriteRenderer.sprite = afterInteract;
            Item item = new Item {
                itemID = itemID,
            };
            GameManager.instance.ReceiveItem(item);
            if (!dialogueManager.dialogueActive) {
                dialogueManager.dialogueLines = new string[] {"You received this item!", "Testing second line!"};
                dialogueManager.currentLine = 0;
                dialogueManager.ShowDialogue();
            }
            interacted = true;
        } 
    }
}
