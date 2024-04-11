using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gold_minus : MonoBehaviour
{
    public TMP_Text goldText;
    private int gold;
    private int kobambi;
    private int meggypalesz;
    private int abszint;
    void Start()
    {
        gold = PlayerPrefs.GetInt("gold");
    }
    void Update()
    {
        gold = PlayerPrefs.GetInt("gold");
        goldText.text = $"Your amount: {gold} gold";
    }

    public void BuyKB()
    {
        if(gold >4) 
        {
            kobambi++;
            gold -= 5;
            PlayerPrefs.SetInt("kobambi", kobambi);
            PlayerPrefs.SetInt("gold", gold);
        }
    }
    public void BuyMP()
    {
        if (gold > 4)
        {
            meggypalesz++;
            gold -= 5;
            PlayerPrefs.SetInt("gold", gold);
            PlayerPrefs.SetInt("meggypalesz", meggypalesz);
        }
    }
    public void BuyAB()
    {
        if (gold > 4)
        {
            abszint++;
            gold -= 5;
            PlayerPrefs.SetInt("gold", gold);
            PlayerPrefs.SetInt("abszint", abszint);

        }
    }

}
