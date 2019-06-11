using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Enemy_Treant : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    public float Move_Speed;
    public bool isWalking;
    Animator anim;


    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;

    private int WalkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;

    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (!canMove)
        {
            myRigidBody.velocity = Vector2.zero;
            return;
        }

        if (isWalking)
        {
            anim.SetBool("isWalkingBool", true);
            walkCounter -= Time.deltaTime;


            switch (WalkDirection)
            {
                case 0:
                    myRigidBody.velocity = new Vector2(0, Move_Speed);
                    anim.SetFloat("input_y", 1);
                    anim.SetFloat("input_x", 0);
                    break;
                case 1:
                    myRigidBody.velocity = new Vector2(Move_Speed, 0);
                    anim.SetFloat("input_y", 0);
                    anim.SetFloat("input_x", 1);
                    break;
                case 2:
                    myRigidBody.velocity = new Vector2(0, -Move_Speed);
                    anim.SetFloat("input_y", -1);
                    anim.SetFloat("input_x", 0);
                    break;
                case 3:
                    myRigidBody.velocity = new Vector2(-Move_Speed, 0);
                    anim.SetFloat("input_x", -1);
                    anim.SetFloat("input_y", 0);
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
            anim.SetBool("isWalkingBool", false);

            waitCounter -= Time.deltaTime;
            myRigidBody.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection()
    {
        WalkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;

    }
}
