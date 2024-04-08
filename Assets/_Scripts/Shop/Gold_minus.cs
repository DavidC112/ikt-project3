using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Gold_minus : MonoBehaviour
{
    public TMP_Text goldText;
    public TMP_Text kobambi_db;
    public TMP_Text meggypalesz_db;
    public TMP_Text abszint_db;
    public int gold;
    private int kobambi;
    private int meggypalesz;
    private int abszint;
    
    void Awake()
    {
        gold = PlayerPrefs.GetInt("gold");
       // kobambi = PlayerPrefs.GetInt("kobambi");
        meggypalesz = PlayerPrefs.GetInt("meggypalesz");
        abszint = PlayerPrefs.GetInt("abszint");
        kobambi_db.text = $"{kobambi} db";
        meggypalesz_db.text = $"{meggypalesz} db";
        abszint_db.text = $"{abszint} db";
    }

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
            PlayerPrefs.SetInt("gold", gold);
            kobambi_db.text = $"{kobambi} db";
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
            meggypalesz_db.text = $"{meggypalesz} db";
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
            abszint_db.text = $"{abszint} db";

        }
    }

}
