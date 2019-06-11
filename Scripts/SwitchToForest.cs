using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchToForest : MonoBehaviour
{
    public void SwitchForest()
    {
        SceneManager.LoadScene(sceneName: "Forest");
        //GameObject.Find("Move").GetComponent<Move>().isAtStore = true;



    }
}
