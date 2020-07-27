using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : Mover {
    // Public fields
    public int hitPoint = 10;
    public int maxHitPoint = 10;
    protected float immuneTime = 1.0f;
    protected float lastImmune;

    // All fighters can receive damage and die
    protected virtual void ReceiveDamage(Damage dmg) {
        if (Time.time - lastImmune > immuneTime) {
            lastImmune = Time.time;
            hitPoint -= dmg.damageAmount;
            pushDirection = (transform.position - dmg.origin).normalized * dmg.pushForce;

            GameManager.instance.ShowText(dmg.damageAmount.ToString(), 25, Color.red, transform.position, Vector3.zero, 0.5f);

            if (hitPoint <= 0) {
                hitPoint = 0;
                Death();
            }
        }
    }

    protected virtual void Death() {

    }
}
