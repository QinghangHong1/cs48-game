using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceDisplay : MonoBehaviour
{
    private GameControl playerAttributes;
    public Text BalanceText;
   
    // Update is called once per frame
    void Update()
    {
        playerAttributes = FindObjectOfType<GameControl>();
        int balance = playerAttributes.money;
        int attack = playerAttributes.attack;
        int health = playerAttributes.health;

        BalanceText.text = "Current balance: " + balance + "\n" 
                         + "Attack: " + attack + "\n" 
                         + "Health: " + health;
    }

}