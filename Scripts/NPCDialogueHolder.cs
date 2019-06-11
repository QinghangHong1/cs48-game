﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NPCDialogueHolder : MonoBehaviour
{

    public Dialogue dialogue;
    private DialogueManager dMAn;
    public bool isStarted;
    //private int HP;
    // Start is called before the first frame update
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("11111");


        if (other.gameObject.name == "PlayerAC")
        {
            if (Input.GetKeyDown(KeyCode.Space))
                {
                    dMAn.StartDialogue(dialogue);
                    isStarted  = true;

                }

        }
    }

}