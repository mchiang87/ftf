using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Mover {
    
    public bool moving;
    public float moveTime;
    public float waitTime;
    public BoxCollider2D walkArea;
    private BoxCollider2D hitbox;
    private float waitTimeCounter;
    private float moveTimeCounter;
    private Vector3 minWalkPoint;
    private Vector3 maxWalkPoint;
    private int randomDirection;
    private Vector3 moveDirection;
    private bool hasWalkArea;
    
    protected override void Start() {
        base.Start();
        boxCollider = GetComponent<BoxCollider2D>();
        waitTimeCounter = waitTime;
        moveTimeCounter = moveTime;
        
        if (walkArea != null) {
            minWalkPoint = walkArea.bounds.min;
            maxWalkPoint = walkArea.bounds.max;
            hasWalkArea = true;
        }
    }

    // Update is called once per frame
    private void FixedUpdate() {
        if (moving) {
            // anim.SetBool("Moving", true);
            moveTimeCounter -= Time.deltaTime;
            UpdateMotor(moveDirection);

            if (moveTimeCounter < 0f) {
                moving = false;
                // anim.SetBool("Moving", false);
                waitTimeCounter = waitTime;
                randomDirection = Random.Range(0, 4);
            }
        } else {
            waitTimeCounter -= Time.deltaTime;
            switch (randomDirection) {
                case 0:
                    if (hasWalkArea && (transform.position.y > maxWalkPoint.y))
                    {
                        moveDirection = new Vector3(0f, -1f, 0f);
                    } else {
                        moveDirection = new Vector3(0f, 1f, 0f);
                    }
                    break;
                case 1:
                    if (hasWalkArea && (transform.position.x > maxWalkPoint.x))
                    {
                        moveDirection = new Vector3(-1f, 0f, 0f);
                    } else {
                        moveDirection = new Vector3(1f, 0f, 0f);
                    }
                    break;
                case 2:
                    if (hasWalkArea && (transform.position.y < minWalkPoint.y))
                    {
                        moveDirection = new Vector3(0f, 1f, 0f);
                    } else {
                        moveDirection = new Vector3(0f, -1f, 0f);
                    }
                    break;
                case 3:
                    if (hasWalkArea && (transform.position.x < minWalkPoint.x))
                    {
                        moveDirection = new Vector3(1f, 0f, 0f);
                    } else {
                        moveDirection = new Vector3(-1f, 0f, 0f);
                    }
                    break;
                default:
                    break;
            }
            if (waitTimeCounter < 0f) {
                moving = true;
                moveTimeCounter = moveTime;
            }
        }
    }
}
