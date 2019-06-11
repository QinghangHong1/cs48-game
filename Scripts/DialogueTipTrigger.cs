using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTipTrigger : MonoBehaviour
{

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "PlayerAC")
        {
            animator.SetBool("isOpen", true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Exit Trigger");
        // Destroy everything that leaves the trigger
       animator.SetBool("isOpen", false);
    }


    // Update is called once per frame
    void Update()
    {

    }
}
