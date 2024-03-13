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
    }
}
