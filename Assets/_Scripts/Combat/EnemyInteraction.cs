using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInteraction : MonoBehaviour
{
    
    [HideInInspector] public GameObject selectedEnemy;
    public GameObject highlight;
    public GameObject bars;
    public CombatUI combatUI;
    public CombatManager combatManager;
    int damageToEnemy;
    Unit currentUnit;

    private void Start()
    {

        highlight = transform.GetChild(1).gameObject;
        bars = transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        combatManager = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        combatUI = GameObject.Find("CombatUI").GetComponent<CombatUI>();
        selectedEnemy = gameObject;
    }

    void OnMouseOver()
    {
        currentUnit = combatManager.currentUnitInTurn.GetComponent<Unit>();

        if (combatManager.attackType == AttackType.Attack && combatManager.state == CombatState.PlayerTurn)
        {

            highlight.SetActive(true);
            bars.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                damageToEnemy = (currentUnit.player.strength + currentUnit.player.dexterity + currentUnit.player.meleeWeapon.weaponDamage) / 5;

                PowerOfMeggyPalesz(damageToEnemy);

                StartCoroutine(AttackEnemy());

            }
        }

        
        else if (combatManager.attackType == AttackType.Ability && combatManager.state == CombatState.PlayerTurn && currentUnit.currentPP > 20)
        {
            
            highlight.SetActive(true);
            bars.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                
                damageToEnemy = (currentUnit.player.strength + currentUnit.player.dexterity + currentUnit.player.meleeWeapon.weaponDamage + currentUnit.player.intelligence) / 4;

                PowerOfMeggyPalesz(damageToEnemy);

                currentUnit.currentPP -= 10;
                currentUnit.SetPP(currentUnit.currentPP);

                StartCoroutine(AttackEnemy());
                
            }
            
        }


    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
        bars.SetActive(false);
    }

    public IEnumerator AttackEnemy()
    {
        combatManager.attackType = AttackType.None;
        highlight.SetActive(false);


        if (combatManager.currentUnitInTurn == combatManager.unitsInCombat[0] && combatManager.unitsInCombat[1] != null)
        {

            combatUI.VisalStateChange(false);
            if (combatManager.unitsInCombat[1].activeSelf == true)
            {
                combatManager.currentUnitInTurn = combatManager.unitsInCombat[1];
            }
            else
            {
                combatManager.UpdateCombatState(CombatState.EnemyTurn);
                combatManager.currentUnitInTurn = combatManager.unitsInCombat[2];
            }

            combatUI.VisalStateChange(true);
        }
        else
        {

            combatUI.VisalStateChange(false);
            combatManager.UpdateCombatState(CombatState.EnemyTurn);
            combatManager.currentUnitInTurn = combatManager.unitsInCombat[2];

        }

        //Ha elfogy enemy hpja akkor deaktivalva lesz az enemy  gamobject
        if (selectedEnemy.GetComponent<Unit>().TakeDamage(damageToEnemy - (selectedEnemy.GetComponent<Unit>().player.endurance / 3)))
        {
            UnAliveEnemy();
        }
        selectedEnemy.GetComponent<Unit>().SetHP(selectedEnemy.GetComponent<Unit>().currentHealth);
        combatManager.UpdateCombatState(combatManager.CheckIfCombatEnds());
        Debug.Log("check if combat ends");
        yield return new WaitForSeconds(0.1f);
        bars.SetActive(false);
        

    }

    private void UnAliveEnemy()
    {
        selectedEnemy.SetActive(false);
        for (int i = 0; i < combatManager.aliveEnemys.Count; i++)
        {
            if (combatManager.aliveEnemys[i] == selectedEnemy)
            {
                combatManager.aliveEnemys.RemoveAt(i);
            }
        }
    }

    void PowerOfMeggyPalesz(int damage)
    {
        if (currentUnit.player.meggyPalesz)
        {
            damage += 5;
            currentUnit.player.meggyPalesz = false;
        }
    }
}
