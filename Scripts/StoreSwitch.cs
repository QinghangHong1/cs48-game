using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreSwitch : MonoBehaviour
{
    public string SceneName;
    public static StoreSwitch h;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        yield return StartCoroutine(sf.FadeToBlack());
       
        SceneManager.LoadScene(sceneName: SceneName);
        yield return StartCoroutine(sf.FadeToClear());
    }

    public void SwitchHome()
    {
        //ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();
        //yield return StartCoroutine(sf.FadeToBlack());
        //DontDestroyOnLoad(GameObject.Find("/Canvas/Player"));
        SceneManager.LoadScene(sceneName: "Forest");
        GameObject.Find("Move").GetComponent<Move>().isAtStore = true;


        //yield return StartCoroutine(sf.FadeToClear());
    }

   
}
