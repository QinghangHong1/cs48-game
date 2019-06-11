using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    public GameObject item;
    public Text healthText;
    public Text costText;
    public Text attackText;
    public Text levelRestrictText;
    private void Start()
    {
        Price itemAttributes = item.GetComponent<Price>();
        int health = itemAttributes.healthIncrease;
        int attack = itemAttributes.attack;
        int price = itemAttributes.price;
        healthText.text = "+" + health.ToString();
        attackText.text = "+" + attack.ToString();
        costText.text = "-" + price.ToString();
        levelRestrictText.text = "Restriction: level " + itemAttributes.level_restrict + "+";
    }
}
