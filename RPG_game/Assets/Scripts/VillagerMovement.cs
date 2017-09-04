using UnityEngine;
using System.Collections;

public class VillagerMovement : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    private float waitCounter;
    public float waitTime;

    private int walkDirection;

    public Collider2D walkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private bool hasWalkZone = false;

    public bool canMove;
    private DialogueManager dialogueManager;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
        if (walkZone != null)
        {
            hasWalkZone = true;
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
        }
        canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(dialogueManager.dialogueActive==false)
        {
            canMove = true;
        }
        if(canMove==false)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }
        if(isWalking==true)
        {
            walkCounter -= Time.deltaTime;

            switch (walkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone==true && transform.position.y >maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone == true && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone == true && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone == true && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                    }
                    break;
            }

            if (walkCounter <= 0)
            {
                isWalking = false;
                waitCounter = waitTime;
            }

        }
        else
        {
            
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (waitCounter<0)
            {
                ChooseDirection();
            }
        }
	}

    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);//kod int-a bira vrijednost 0-3 
        isWalking = true;
        walkCounter = walkTime;
    }
}
