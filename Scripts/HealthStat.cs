using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthStat : MonoBehaviour
{
    private Image content;

    private int HPmanage;

    [SerializeField]
    private float lerpSpeed;

    private float currentFill;

    public float MyCurrentFill
    {
        get
        {
            return currentFill;
        }
        set
        {
            currentFill = value;
        }
    }

    public float MyMaxValue { get; set; }

    private float currentValue;

    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                currentValue = 0;
            }
            else
            {
                currentValue = value;
            }

            currentFill = currentValue / MyMaxValue;
            //Debug.Log(currentFill);

        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        HPmanage = GameObject.Find("BattleAttack").GetComponent<GameControl>().HP;
        Debug.Log(HPmanage);
        content = GetComponent<Image>();
        MyCurrentValue = HPmanage;
        //Debug.Log(currentValue);

    }

    // Update is called once per frame
    void Update()
    {
        HPmanage = GameObject.Find("BattleAttack").GetComponent<GameControl>().HP;
        if (currentValue != HPmanage)
        {
            MyCurrentValue = HPmanage;
            //Debug.Log(currentValue);
        }


        //Debug.Log(MyCurrentValue);
        if(currentFill != content.fillAmount)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public void Initialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }



}
