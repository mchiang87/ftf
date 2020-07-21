using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : Interactable {

    protected SpriteRenderer spriteRenderer;
    public Sprite interacted;
    public int itemID;

    protected void Start() {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Interact() {
        spriteRenderer.sprite = interacted;
        Item item = new Item {
            itemID = itemID,
        };
        GameManager.instance.ReceiveItem(item);
    }
}
