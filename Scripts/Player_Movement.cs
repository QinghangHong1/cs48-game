using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [SerializeField]
    private HealthStat health;

    private float initialHealth = 100;

    Rigidbody2D rbody;
    Animator anim;
    public float MoveSpeed;
    private float CurrentMoveSpeed;
    public bool isAtStore = false;

    public bool canMove;
    // Start is called before the first frame update
    void Awake()
    {
        health.Initialize(initialHealth, initialHealth);

        canMove = true;
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if (GameObject.Find("Move").GetComponent<Move>().isAtStore == true)
        {
            this.SetStorePosition();
            GameObject.Find("Move").GetComponent<Move>().isAtStore = false;
        }
        else if (GameObject.Find("Move").GetComponent<MoveCave>().isAtCave == true)
        {
            this.SetCavePosition();
            GameObject.Find("Move").GetComponent<MoveCave>().isAtCave = false;
        }
        else
        {
            transform.position = GameObject.Find("BattleAttack").GetComponent<GameControl>().position;
        }
    }

    //private void GetInput()
    //{
    //    if (Input.GetKeyDown(KeyCode.I))
    //    {
    //        health.MyCurrentValue -= 10;
    //    }
    //    if (Input.GetKeyDown(KeyCode.O))
    //    {
    //        health.MyCurrentValue += 10;
    //    }
    //    Debug.Log("GetInput!");
    //}

    // Update is called once per frame
    void Update()
    {
        //     health.MyCurrentValue = 100;

        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    health.MyCurrentValue -= 10;
        //    Debug.Log("GetInput!");
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    health.MyCurrentValue += 10;
        //    Debug.Log("GetInput!");
        //}

        GameObject.Find("BattleAttack").GetComponent<GameControl>().position = this.transform.position;
        if (!canMove)
        {
            rbody.velocity = Vector2.zero;
            anim.SetBool("is_walking", false);
            return;
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 && Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1)
        {
           // Debug.Log("diognal");
            CurrentMoveSpeed = MoveSpeed / 2.0f;
        }
        else
        {
            CurrentMoveSpeed = MoveSpeed;
        }

        Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (movement_vector != Vector2.zero)
        {
            anim.SetBool("is_walking", true);
            anim.SetFloat("input_x", movement_vector.x);
            anim.SetFloat("input_y", movement_vector.y);
        }
        else
        {
            anim.SetBool("is_walking", false);
        }

        rbody.MovePosition(rbody.position + movement_vector * CurrentMoveSpeed* Time.deltaTime);



    }



    public void SetStorePosition()
    {
        Vector3 position;
        position.x = (float)5.3;
        position.y = (float)-34.7;
        position.z = 0;
        transform.position = position;

    }
    public void SetCavePosition()
    {
        Vector3 position;
        position.x = (float)47.6;
        position.y = (float)-45.4;
        position.z = 0;
        transform.position = position;
    }

   
}
