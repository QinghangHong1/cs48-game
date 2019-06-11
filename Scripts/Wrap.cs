using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    public Transform warpTarget;
    public Player_Movement PM;

    private void Start()
    {
        PM = FindObjectOfType<Player_Movement>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "PlayerAC")
        {

            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();

            PM.canMove = false;

            yield return StartCoroutine(sf.FadeToBlack());

            //  Debug.Log("An object Collided.");
            other.gameObject.transform.position = warpTarget.position;
            Camera.main.transform.position = warpTarget.position;

            PM.canMove = true;

            yield return StartCoroutine(sf.FadeToClear());
        }

    }

}
