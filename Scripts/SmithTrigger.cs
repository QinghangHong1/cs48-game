using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithTrigger : MonoBehaviour
{

    private QuestManager theQM;

    public int questNumber;

    public bool startQuest;
    public bool endQuest;

    public GameControl GC;

    // Start is called before the first frame update
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();
        GC = FindObjectOfType<GameControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) 
    { 
        if(other.gameObject.name == "PlayerAC")
        {
            if(!theQM.questCompleted[questNumber])
            {
                if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.quests[questNumber].gameObject.SetActive(true);
                    theQM.quests[questNumber].StartQuest();
                    GC.money+=50;
                }
                if(endQuest && theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.quests[questNumber].gameObject.SetActive(false);
                    theQM.quests[questNumber].EndQuest();
                
                    gameObject.SetActive(false);                   
                    theQM.quests[++questNumber].gameObject.SetActive(true);
                    
                    
                }
            }
        }
   
    }
}
