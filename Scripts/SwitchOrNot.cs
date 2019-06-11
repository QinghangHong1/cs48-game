using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  SwicthOrNot: MonoBehaviour
{
    // Start is called before the first frame update
    public static SwicthOrNot i; 
    public bool isAtStore;
    //public bool isAtCave;
    public void Awake()
    {
        if(i == null)
        {
            DontDestroyOnLoad(gameObject);
            i = this;
        }
        else if(i != this)
        {
            Destroy(gameObject);
        }
    }
}
