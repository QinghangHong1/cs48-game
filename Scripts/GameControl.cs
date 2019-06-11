using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl control;
    public string userName;
    public string userEmail;
    public int HP;
    public int money;
    public int attack;
    public int health;
    public int level;
    public int QuestCount;
    public bool isQuestComplete = false;
    public int EnemyKilled;
    public int numComeToStore;
    public bool inQuest;
    public Vector3 position;
    private void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
    }
}
