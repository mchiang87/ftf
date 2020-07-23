using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover {
    // Experience
    public int expValue = 1;
    public GameObject drop;

    // Logic
    public float triggerLength = 0.25f;
    public float chaseLength = 1;
    public float moveTime;
    public float waitTime;
    private float waitTimeCounter;
    private float moveTimeCounter;
    private bool moving;
    private bool chasing;
    private bool collidingWithPlayer;
    private bool collidingWithEnvironment;
    private Transform playerTransform;
    private Vector3 currentPosition;
    private Vector3 moveDirection;
    private Animator anim;

    // Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start() {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        waitTimeCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
        moveTimeCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
        moving = false;
    }

    private void FixedUpdate() {
        currentPosition = transform.position;
        if (moving) {
            chasing = false;
            anim.SetBool("EnemyMoving", true);
            moveTimeCounter -= Time.deltaTime;
            Walk(moveDirection);

            if (moveTimeCounter < 0f) {
                moving = false;
                anim.SetBool("EnemyMoving", false);
                waitTimeCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
            }
        } else {
            if (Vector3.Distance(playerTransform.position, currentPosition) < chaseLength) {
                if (Vector3.Distance(playerTransform.position, currentPosition) < triggerLength) {
                    chasing = true;
                    moving = false;
                    anim.SetBool("EnemyMoving", true);
                }
                if (chasing) {
                    if (!collidingWithPlayer) {
                        Walk((playerTransform.position - currentPosition).normalized);
                        moveTimeCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
                    }
                }
            } else {
                chasing = false;
                waitTimeCounter -= Time.deltaTime;
                if (waitTimeCounter < 0f) {
                    moving = true;
                    moveTimeCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
                    moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                }
            }
        }

        // Check for overlap
        collidingWithPlayer = false;
        collidingWithEnvironment = false;
        boxCollider.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++) {
            if (hits[i] == null) {
                continue;
            }

            if (hits[i].tag == "Fighter" && hits[i].name == "Player") {
                anim.SetTrigger("EnemyAttack");
                collidingWithPlayer = true;
            }

            if (hits[i].name == "Wall") {
                collidingWithEnvironment = true;
            }

            // Array not cleaned, so doing so here
            hits[i] = null;
        }
    }

    protected override void Death() {
        anim.SetTrigger("EnemyDeath");
        Instantiate(drop, currentPosition, Quaternion.identity);
        GameManager.instance.GrantExp(expValue);
        GameManager.instance.ShowText("+" + expValue + " exp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
