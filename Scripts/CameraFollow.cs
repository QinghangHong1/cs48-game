using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Camera mycam;
    public float m_speed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        mycam = GetComponent<Camera>();
        
    }

    // Update is called once per frame
    void Update()
    {
        mycam.orthographicSize = (Screen.height / 100f) / 2f;

        if (target)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, m_speed) + new Vector3(0,0,-10);
        }
    }

}
