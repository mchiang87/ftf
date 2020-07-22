using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover {
    private SpriteRenderer spriteRenderer;
    private bool isAlive = true;
    public bool canMove;
    private float lastAttack;
    private float cooldown = 0.1f;
    private Animator anim;

    protected override void Start() {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        canMove = true;
    }

    protected override void ReceiveDamage(Damage dmg) {
        if (!isAlive) {
            return;
        }
        base.ReceiveDamage(dmg);
        GameManager.instance.OnHitPointChange();
    }

    private void FixedUpdate() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (isAlive && canMove) {
            UpdateMotor(new Vector3(x, y, 0));
            anim.SetFloat("MoveX", x);
            anim.SetFloat("MoveY", y);
            anim.SetBool("PlayerMoving", isMoving);
            anim.SetFloat("LastMoveX", lastMove.x);
            anim.SetFloat("LastMoveY", lastMove.y);

            if (Input.GetKeyDown(KeyCode.Space)) {
                if (Time.time - lastAttack > cooldown) {
                    lastAttack = Time.time;
                    Attack();
                }
            }
        }
        if (!canMove) {
            anim.SetBool("PlayerMoving", false);
        }
    }

    public void SwapSprite(int skinId) {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinId];
    }

    public void OnLevelUp() {
        maxHitPoint++;
        hitPoint = maxHitPoint;
    }

    public void SetLevel(int level) {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }

    public void Attack() {
        anim.SetTrigger("Attack");
    }

    public void Heal (int healingAmount) {
        if (hitPoint == maxHitPoint) {
            return;
        }
        hitPoint += healingAmount;
        if (hitPoint > maxHitPoint) {
            hitPoint = maxHitPoint;
        }
        GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnHitPointChange();
    }

    protected override void Death() {
        isAlive = false;
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
    }

    public void Respawn() {
        Heal(maxHitPoint);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
}
