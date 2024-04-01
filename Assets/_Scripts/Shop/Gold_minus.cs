using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gold_minus : MonoBehaviour
{
    public TMP_Text goldText;
    public int gold = 20;
    public int kobambi;
    public int meggypalesz;
    public int abszint;

    void Update()
    {
        goldText.text = $"Your amount: {gold} gold";
    }

    public void BuyKB()
    {
        if(gold >4) 
        {
            kobambi++;
            gold -= 5;
            PlayerPrefs.SetInt("kobambi", kobambi);
        }
    }
    public void BuyMP()
    {
        if (gold > 4)
        {
            meggypalesz++;
            gold -= 5;
            PlayerPrefs.SetInt("meggypalesz", meggypalesz);
        }
    }
    public void BuyAB()
    {
        if (gold > 4)
        {
            abszint++;
            gold -= 5;
            PlayerPrefs.SetInt("abszint", abszint);
        }
    }

}
