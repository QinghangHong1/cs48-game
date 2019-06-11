using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCave : MonoBehaviour
{
    public static MoveCave n;
    public bool isAtCave;
    private void Awake()
    {
        if (n == null)
        {
            DontDestroyOnLoad(gameObject);
            n = this;
        }
        else if (n != this)
        {
            Destroy(gameObject);
        }
    }
}
