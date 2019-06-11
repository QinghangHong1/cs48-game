using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public static Move m;
    public bool isAtStore;
    private void Awake()
    {
        if(m == null)
        {
            DontDestroyOnLoad(gameObject);
            m = this;
        }else if(m != this)
        {
            Destroy(gameObject);
        }
    }
}

