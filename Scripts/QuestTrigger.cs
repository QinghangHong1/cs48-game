using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{

    private QuestManager theQM;

    public int questNumber;

    public bool startQuest;
    public bool endQuest;

    private GameControl GC;


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
            /*if(!theQM.questCompleted[questNumber])
            {
                if (startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.quests[questNumber].gameObject.SetActive(true);
                    theQM.quests[questNumber].StartQuest();
                }
                if(endQuest && theQM.quests[questNumber].gameObject.activeSelf && theQM.quests[questNumber].isComplete==true)
                {
                    //theQM.quests[questNumber].gameObject.SetActive(false);
                    theQM.quests[questNumber].EndQuest();
                    //GC.money += 50;

                    //gameObject.SetActive(false);

                    //if(questNumber == 2)
                    //{
                    //    return;
                    //}
                    //theQM.quests[++questNumber].gameObject.SetActive(true);

                    //theQM.quests[questNumber].StartQuest();
                    
                    
                }
            }*/
            if(GC.QuestCount == 0 && GC.inQuest == false)
            {
                theQM.quests[0].gameObject.SetActive(true);
                theQM.quests[0].StartQuest();
                //Debug.Log("start 0 quest");
                GC.isQuestComplete = false;
                GC.inQuest = true;

            }
            if (GC.QuestCount == 0 && GC.isQuestComplete == true && GC.inQuest == true)
            {
                theQM.quests[0].EndQuest();
                theQM.quests[0].gameObject.SetActive(false);
                GC.isQuestComplete = false;
                //Debug.Log("end 0 quest");
                GC.QuestCount++;
                GC.inQuest = false;


            }
            if (GC.QuestCount == 1 && GC.inQuest == false)
            {
                theQM.quests[1].gameObject.SetActive(true);

                theQM.quests[1].StartQuest();
                GC.isQuestComplete = false;
                GC.inQuest = true;


            }
            if (GC.QuestCount == 1 && GC.isQuestComplete == true && GC.inQuest==true)
            {
                theQM.quests[1].EndQuest();
                theQM.quests[1].gameObject.SetActive(false);
                GC.isQuestComplete = false;
                GC.QuestCount++;
                GC.inQuest = false;


            }
            if (GC.QuestCount == 2 && GC.inQuest == false)
            {
                theQM.quests[2].gameObject.SetActive(true);

                theQM.quests[2].StartQuest();
                GC.isQuestComplete = false;
                GC.inQuest = true;


            }
            if (GC.QuestCount == 2 && GC.isQuestComplete == true&& GC.inQuest==true)
            {
                theQM.quests[2].EndQuest();
                theQM.quests[2].gameObject.SetActive(false);
                GC.isQuestComplete = false;
                GC.QuestCount++;
                GC.inQuest = false;


            }
            else
            {
                return;
            }
        }
   
    }
}
