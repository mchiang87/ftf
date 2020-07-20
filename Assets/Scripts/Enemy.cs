using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    // Experience
    public int expValue = 1;

    // Logic
    public float triggerLength = 0.25f;
    public float chaseLength = 1;
    public float timeToMove;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    private float timeToMoveCounter;
    private bool moving;
    private bool chasing;
    private bool collidingWithPlayer;
    private bool collidingWithEnvironment;
    private Transform playerTransform;
    private Vector3 startingPosition;
    private Vector3 moveDirection;
    private Animator anim;

    // Hitbox
    public ContactFilter2D filter;
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];

    protected override void Start()
    {
        base.Start();
        playerTransform = GameManager.instance.player.transform;
        startingPosition = transform.position;
        hitbox = transform.GetChild(0).GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    private void FixedUpdate()
    {
        // Is player in range
        if (Vector3.Distance(playerTransform.position, startingPosition) < chaseLength)
        {
            if (Vector3.Distance(playerTransform.position, startingPosition) < triggerLength)
            {
                chasing = true;
                anim.SetBool("EnemyMoving", true);
            }
            if (chasing)
            {
                if (!collidingWithPlayer)
                {
                    UpdateMotor((playerTransform.position - transform.position).normalized);
                }
            } else {
                UpdateMotor(startingPosition - transform.position);
            }
        } else {
            chasing = false;
            if (moving)
            {
                anim.SetBool("EnemyMoving", true);
                timeToMoveCounter -= Time.deltaTime;
                UpdateMotor(moveDirection);

                if (timeToMoveCounter < 0)
                {
                    moving = false;
                    anim.SetBool("EnemyMoving", false);
                    timeBetweenMoveCounter = timeBetweenMove;
                }
            } else {
                timeBetweenMoveCounter -= Time.deltaTime;
                if (timeBetweenMoveCounter < 0f)
                {
                    moving = true;
                    timeToMoveCounter = timeToMove;
                    moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
                }
            }
        }

        // Check for overlap
        collidingWithPlayer = false;
        collidingWithEnvironment = false;
        boxCollider.OverlapCollider(filter, hits);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
            {
                continue;
            }

            if (hits[i].tag == "Fighter" && hits[i].name == "Player")
            {
                collidingWithPlayer = true;
            }

            if (hits[i].name == "Wall")
            {
                collidingWithEnvironment = true;
            }

            // Array not cleaned, so doing so here
            hits[i] = null;
        }
    }

    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.instance.GrantExp(expValue);
        GameManager.instance.ShowText("+" + expValue + " exp", 30, Color.magenta, transform.position, Vector3.up * 40, 1.0f);
    }
}
