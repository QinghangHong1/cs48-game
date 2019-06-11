using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreDialogueHolder : MonoBehaviour
{
    public Dialogue firstDialogue;
    public Dialogue secondDialogue;
    private DialogueManager dMAn;
    private GameControl GC;
    public bool isStarted;
    // Start is called before the first frame update
    void Start()
    {
        dMAn = FindObjectOfType<DialogueManager>();
        GC = FindObjectOfType<GameControl>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {


        if (other.gameObject.name == "PlayerAC")
        {
                if (Input.GetKeyDown(KeyCode.Space)) {
                    if (GC.numComeToStore == 0)
                    {
                    if (GC.inQuest==true && GC.QuestCount==0 && GC.isQuestComplete==false) {
                        GC.isQuestComplete = true;
                        dMAn.StartDialogue(firstDialogue);
                        GC.money += 50;

                        GC.numComeToStore++;
                    }
                    }
                else
                {
                    dMAn.StartDialogue(secondDialogue);
                    isStarted = true;
                }

            }
        }
    }

}