using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject item;
    private GameControl playerAttributes;
    public GameObject button;

    public void BuyItem()
    {
        playerAttributes = GameObject.Find("BattleAttack").GetComponent<GameControl>();
        Price itemAttributes = item.GetComponent<Price>();
        int price = itemAttributes.price;
        int itemAttack = itemAttributes.attack;
        int healthIncrease = itemAttributes.healthIncrease;
        int money = playerAttributes.money;
        int health = playerAttributes.health;
        int playerAttack = playerAttributes.attack;
        if (price <= money)
        {
            playerAttributes.money = money - price;
            playerAttributes.attack = playerAttack + itemAttack;
            playerAttributes.health = health + healthIncrease;
        }

    }

    private void Update()
    {
        playerAttributes = GameObject.Find("BattleAttack").GetComponent<GameControl>();
        Price itemAttributes = item.GetComponent<Price>();
        int price = itemAttributes.price;
        int level_restrict = itemAttributes.level_restrict;
        int money = playerAttributes.money;
        int level = playerAttributes.level;
        if (price <= money && level_restrict <= level)
        {
            button.GetComponent<Button>().interactable = true;
        }
        else
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
}
