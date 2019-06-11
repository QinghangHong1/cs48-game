using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestHolder : MonoBehaviour
{

    public int questNumber;
    //public bool isComplete;

    public QuestManager theQM;

    public Dialogue startText;
    public Dialogue endText;
    //public Animator StartAnimator;
    //public Animator EndAnimator;
    public Animator QuestComplete;

    public bool isMeetQuest;

    //public string targetItem;
    public bool isEnemyQuest;
    public StoreDialogueHolder DH;
    public string targetEnemy;
    public int enemiesToKill;
    //private int enemyKillCount;

    public bool isLevelQuest;
    public int requiredLevel;
    public Player_Movement player;

    private GameControl GC;

    //
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player_Movement>();
        GC = FindObjectOfType<GameControl>();
    }

    // Update is called once per frame
    //void OnTriggerEnter2D(Collider2D other)
    void Update()
    {
        if (isMeetQuest)
        {
            if(DH.isStarted == true)
            {
                //theQM.itemCollected = null;
                //EndQuest();
                GC.isQuestComplete = true;
                //QuestComplete.SetBool("isOpen", true);
            }
        }
        if (isEnemyQuest)
        {
            //if (theQM.enemyKilled == targetEnemy)
            //{
            //    theQM.enemyKilled = null;
            //    GC.EnemyKilled++;
            //}
            if(GC.EnemyKilled >= enemiesToKill)
            {
                //Debug.Log("EnemyKilled");
                //EndQuest();
                GC.isQuestComplete = true;
                //QuestComplete.SetBool("isOpen", true);

            }
        }
        if(isLevelQuest)
        {
            if (GC.level >= requiredLevel)
            {
                // EndQuest();
                GC.isQuestComplete = true;
                //QuestComplete.SetBool("isOpen", true);


            }
        }
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.name == "PlayerAC")
    //    {
    //        if(isComplete == true)
    //        {
    //            EndQuest();
    //        }
    //    }
    //}

    public void StartQuest()
    {
        theQM.ShowQuestText(startText);
       // StartAnimator.SetBool("QuestAccepted", true);
    }



    public void EndQuest()
    {

        theQM.ShowQuestText(endText);
        theQM.questCompleted[questNumber] = true;
        //gameObject.SetActive(false);
        //EndAnimator.SetBool("QuestComplete", true);

    }
}
