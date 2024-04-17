using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Items : MonoBehaviour
{
    private GameObject GameObject;
    public CombatManager _combatManager;
    private GameObject _canvas;
    public TMP_Text kobambi, meggypalesz, abszint;
    [SerializeField]
    
    private GameObject selectedPlayer;
    private GameObject highlight;
    public Button itemButton;


    void Start()
    {
        _combatManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<CombatManager>();

        highlight = transform.GetChild(1).gameObject;
        SetItemValues();
        selectedPlayer = gameObject;
    }
    

    void Update()
    {
        
    }

    public void SetItemValues()
    {
        _combatManager._kobambiValue = PlayerPrefs.GetInt("kobambi");
        _combatManager._meggypaleszValue = PlayerPrefs.GetInt("meggypalesz");
        _combatManager._abszintValue = PlayerPrefs.GetInt("abszint");

        kobambi.text = _combatManager._kobambiValue.ToString();
        meggypalesz.text = _combatManager._meggypaleszValue.ToString();
        abszint.text = _combatManager._abszintValue.ToString();
    }

    public void UseKobambi()
    {
        if(_combatManager._kobambiValue == 0)
        {
            return;
        }
        
        _combatManager.item = Item.Kobambi;
        
    }

    public void UseMeggyPalesz()
    {
        if (_combatManager._meggypaleszValue == 0)
        {
            return;
        }
        _combatManager._meggypaleszValue--;
        _combatManager.currentUnitInTurn.GetComponent<Unit>().player.meggyPalesz = true;
        PlayerPrefs.SetInt("meggypalesz", _combatManager._meggypaleszValue);
        SetItemValues();
        highlight.SetActive(false);
    }

    public void UseAbszint()
    {
        if (_combatManager._abszintValue == 0)
        {
            return;
        }
        _combatManager.item = Item.Abszint;
        
    }

    private void OnMouseOver()
    {
        if (_combatManager.item == Item.None)
        {
            return;
        }

        if (_combatManager.item == Item.Kobambi)
        {
            highlight.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                selectedPlayer.GetComponent<Unit>().Heal(10);
                _combatManager.item = Item.None;
                _combatManager._kobambiValue--;
                PlayerPrefs.SetInt("kobambi", _combatManager._kobambiValue);
                SetItemValues();
                highlight.SetActive(false);

            }
        }
        if (_combatManager.item == Item.Abszint)
        {
            highlight.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                selectedPlayer.GetComponent<Unit>().AddPP(20);
                _combatManager.item = Item.None;
                _combatManager._abszintValue--;
                PlayerPrefs.SetInt("abszint", _combatManager._abszintValue);
                SetItemValues();
                highlight.SetActive(false);

            }
        }
    }
    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }

}


