using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Fighter {
    // Experience
    public int expValue = 1;
    public GameObject drop;
    [SerializeField]
    public GameObject projectile;

    // Logic
    public float noticeLength = 2;
    public float rangedLength = 1;
    public float moveTime;
    public float waitTime;
    public float rangedCooldown;
    public float meleeCooldown;
    public bool hasRanged;
    public bool hasMelee;
    private float rangedTimeCounter;
    private float meleeTimeCounter;
    private float waitTimeCounter;
    private float moveTimeCounter;
    private bool moving;
    private bool collidingWithPlayer;
    private bool collidingWithEnvironment;
    private Transform playerTransform;
    private Vector3 currentPosition;
    private Vector3 moveDirection;
    private Animator anim;

    // Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private RaycastHit2D hit;
    private Collider2D[] hits = new Collider2D[10];
    private float distanceFromPlayer;

    protected override void Start() {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        if (hasMelee) {
            hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        }
        anim = GetComponent<Animator>();
        waitTimeCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
        moveTimeCounter = Random.Range(moveTime * 0.75f, moveTime * 1.25f);
        moving = false;
        rangedTimeCounter = rangedCooldown;
        meleeTimeCounter = meleeCooldown;
    }

    private void FixedUpdate() {
        currentPosition = transform.position;
        meleeTimeCounter -= Time.deltaTime;
        rangedTimeCounter -= Time.deltaTime;
        distanceFromPlayer = Vector3.Distance(playerTransform.position, currentPosition);
        if (moving) {
            anim.SetBool("EnemyMoving", true);
            moveTimeCounter -= Time.deltaTime;
            Walk(moveDirection);

            if (moveTimeCounter < 0f) {
                moving = false;
                anim.SetBool("EnemyMoving", false);
                waitTimeCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
            }
        } else {
            // Does enemy notice player?
            if (distanceFromPlayer < noticeLength) {
                if (distanceFromPlayer < rangedLength && hasRanged && hasMelee) {
                    if (inLOS(playerTransform.position, currentPosition)) {
                        // choose to chase or ranged attack
                    }                
                } else if (distanceFromPlayer < rangedLength && hasRanged && rangedTimeCounter < 0f) {
                    if (inLOS(playerTransform.position, currentPosition)) {
                        Ranged();
                    }
                }
                    // chase 
                if (!collidingWithPlayer) {
                    Chase();
                }
            } else {
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

            if (hits[i].tag == "Fighter" && hits[i].name == "Player" && meleeTimeCounter < 0f) {
                anim.SetTrigger("EnemyAttack");
                collidingWithPlayer = true;
                meleeTimeCounter = meleeCooldown;
            }

            if (hits[i].name == "Wall") {
                collidingWithEnvironment = true;
            }

            // Array not cleaned, so doing so here
            hits[i] = null;
        }
    }

    private bool inLOS(Vector3 playerPosition, Vector3 currentPosition) {
        var rayDirection = transform.TransformDirection(playerPosition - currentPosition);
        hit = Physics2D.Raycast(currentPosition, rayDirection);
        if (Physics2D.Raycast(currentPosition, rayDirection)) {
            if (hit.transform == playerTransform) {
                return true;
            }
        }
        return false;
    }
    private void Ranged() {
        Instantiate(projectile, transform.position, Quaternion.identity);
        rangedTimeCounter = rangedCooldown;
    }

    private void Chase() {
        anim.SetBool("EnemyMoving", true);
        Walk((playerTransform.position - currentPosition).normalized);
    }

    protected virtual void Special() {

    }

    protected override void Death() {
        anim.SetTrigger("EnemyDeath");
        if (drop != null) {
            Instantiate(drop, currentPosition, Quaternion.identity);
        }
        GameManager.instance.GrantExp(expValue);
        GameManager.instance.ShowText("+" + expValue + " exp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
