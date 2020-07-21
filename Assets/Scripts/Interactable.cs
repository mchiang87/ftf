using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : Collidable {
    protected override void OnCollide(Collider2D coll) {
        if (coll.name == "Player") {
            if (Input.GetKeyDown(KeyCode.Return)) {
                Interact();
            }
        }
    }

    protected virtual void Interact() {
    }
}
