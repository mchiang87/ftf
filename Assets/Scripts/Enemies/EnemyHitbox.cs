using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitbox : Collidable {
    public int damage;
    public float pushForce = 3.0f;

    protected override void OnCollide(Collider2D coll) {
        if (coll.tag == "Fighter" && coll.name == "Player") {
            // Create a new damage object
            Damage dmg = new Damage(transform.position, damage, pushForce);

            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
