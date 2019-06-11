using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeUseButton : MonoBehaviour
{
    public Button changeSceneButton;
    public Button startButton;
    public GameObject GO;

    public void ButtonUse()
    {
        changeSceneButton.interactable = true;
        startButton.interactable = true;
        GO.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
