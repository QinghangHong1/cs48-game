using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroductionTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<IntroductionManager>().StartDialogue(dialogue);
    }
}
