using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    public CombatManager combatManager;
    private GameObject _canvas;
    public bool _teammate;
    private void Start()
    {
        _teammate = combatManager.characterPrefab.GetComponent<Unit>().player.isTeamMate;
    }

    private void Update()
    {
        if (combatManager.attackType == AttackType.Items && Input.GetMouseButton(1))
        {
            _canvas.transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    public void VisalStateChange(bool state)
    {
        _canvas = combatManager.currentUnitInTurn.transform.GetChild(0).gameObject;
        _canvas.transform.GetChild(0).gameObject.SetActive(state);

    }

    public void OnAttack()
    {
        CombatManager.instance.attackType = AttackType.Attack;
    }
    public void OnAbility()
    {
        CombatManager.instance.attackType = AttackType.Ability;
    }
    public void OnItem()
    {
        Debug.Log("Item");
        CombatManager.instance.attackType = AttackType.Items;
        _canvas = CombatManager.instance.currentUnitInTurn.transform.GetChild(0).gameObject;
        _canvas.transform.GetChild(2).gameObject.SetActive(true);
        CombatManager.instance.currentUnitInTurn.GetComponent<Items>().SetItemValues();

    }
}
