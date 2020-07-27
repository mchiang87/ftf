using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : Collidable {
    public float moveSpeed;
    public int damage;
    public float pushForce = 3.0f;
    private Vector3 originalSize;
    private Vector3 moveDirection;
    private Vector3 moveDelta;
    private Transform playerTransform;

    protected override void Start() {
        base.Start();
        originalSize = transform.localScale;
        playerTransform = GameManager.instance.player.transform;
        moveDirection = (playerTransform.position - transform.position).normalized * moveSpeed;
    }

    protected void FixedUpdate() {
        // base.Update();
        
        moveDelta = new Vector3(moveDirection.x,moveDirection.y, 0);
        if (moveDelta.x > 0) {
            transform.localScale = originalSize;
        } else if (moveDelta.x < 0) {
            transform.localScale = new Vector3(originalSize.x * -1, originalSize.y, originalSize.z);
        }
        transform.Translate(moveDelta.x * Time.deltaTime, moveDelta.y * Time.deltaTime, 0);
        Destroy(gameObject, 10f);
    }    

    protected override void OnCollide(Collider2D coll) {
        if (coll.tag == "Fighter" && coll.name == "Player") {
            // Create a new damage object
            Damage dmg = new Damage(transform.position, damage, pushForce);
            Destroy(gameObject);
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }
}
