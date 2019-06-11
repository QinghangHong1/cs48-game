using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayPlayerAttributes : MonoBehaviour
{
    // Start is called before the first frame update
    public Text moneyText;
    public Text attackText;
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        GameControl playerAttributes = FindObjectOfType<GameControl>();
        if (moneyText != null)
        {
            moneyText.text = playerAttributes.money.ToString();
        }

        if (attackText != null)
        {
            attackText.text = playerAttributes.attack.ToString();
        }

        if (healthText != null)
        {
            healthText.text = playerAttributes.health.ToString();
        }

    }
}
