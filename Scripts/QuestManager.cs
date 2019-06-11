using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestHolder[] quests;
    public bool[] questCompleted;

    //public Dialogue dialogue;

    public DialogueManager theDM;
    
    //public string itemCollected;
    //public string enemyKilled;
    // Start is called before the first frame update
    void Start()
    {
        questCompleted = new bool[quests.Length];   
    }



// Update is called once per frame
//void Update()
    //{
        
    //}

    public void ShowQuestText(Dialogue questText)
    {
        theDM.StartDialogue(questText);
    }


}
