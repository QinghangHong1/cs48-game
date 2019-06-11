using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class connet : MonoBehaviour
{
    public bool StartMenu = false;
    // Start is called before the first frame update
    public void GoToTheGame()
    {
        StartMenu = true;
        SceneManager.LoadScene(sceneName: "StartMenu");
    }


}
