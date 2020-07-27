using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable {
    // Damage struct
    public int[] damagePoint = {1, 2, 3, 4, 5, 6, 7};
    public float[] pushForce = {2.0f, 2.2f, 2.5f, 3f, 3.2f, 3.6f, 4.0f};

    // Upgrade
    public int weaponLevel = 0;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Start() {
        base.Start();
    }

    protected override void Update() {
        base.Update();
    }

    protected override void OnCollide(Collider2D coll) {
        if (coll.tag == "Fighter") {
            if (coll.name == "Player") {
                return;
            }

            Damage dmg = new Damage (transform.position,  damagePoint[weaponLevel], pushForce[weaponLevel]);
            coll.SendMessage("ReceiveDamage", dmg);
        }
    }

    public void Upgrade() {
        weaponLevel++;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];

        // Change Stats
    }

    public void SetWeaponLevel(int level) {
        weaponLevel = level;
        spriteRenderer.sprite = GameManager.instance.weaponSprites[weaponLevel];
    }
}
