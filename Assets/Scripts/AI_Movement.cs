using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Movement : MonoBehaviour {

    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidBody;

    public bool isWalking; // Default is false;
    private bool hasWalkZone; 
    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;

    private int walkDirection;

    public BoxCollider2D walkZone;
    GameObject walkArea;

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody2D>();

        walkArea = GameObject.FindWithTag("WalkArea");
        walkZone = walkArea.GetComponent<BoxCollider2D>();

        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();

        if(walkZone != null) // If there is a zone, get the boundaries. Works if box zone is small
        {
            minWalkPoint = walkZone.bounds.min; // Bottom left corner of collider
            maxWalkPoint = walkZone.bounds.max; // top right corner of collider
            hasWalkZone = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (isWalking == true)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    myRigidBody.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone == true && transform.position.y > maxWalkPoint.y) // hasWalkZone has been set to true in the start funtion if there is a collider;
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone == true && transform.position.x > maxWalkPoint.x) // hasWalkZone has been set to true in the start funtion if there is a collider;
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone == true && transform.position.y < minWalkPoint.y) // hasWalkZone has been set to true in the start funtion if there is a collider;
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone == true && transform.position.x < minWalkPoint.x) // hasWalkZone has been set to true in the start funtion if there is a collider;
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero; //makes velocity for x and y 0 when idle.
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
