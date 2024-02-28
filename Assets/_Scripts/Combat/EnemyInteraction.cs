using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class EnemyInteraction : MonoBehaviour
{
    
    [HideInInspector] public GameObject selectedEnemy;
    public GameObject highlight;
    public CombatUI combatUI;
    public CombatManager combatManager;
    //private Unit _selectedUnit;


    private void Start()
    {

        highlight = transform.GetChild(0).gameObject;
        combatManager = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        combatUI = GameObject.Find("CombatUI").GetComponent<CombatUI>();
    }

    void OnMouseOver()
    {
        
        if (combatManager.attackType == AttackType.Attack && combatManager.state == CombatState.PlayerTurn)
        {
            
            highlight.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                
                //Damage the opponent
                if (combatManager.currentUnitInTurn == combatManager.unitsInCombat[0] && combatManager.player.teamMate)
                {
                    combatUI.HideActionVisual(0);
                    combatManager.currentUnitInTurn = combatManager.unitsInCombat[1];
                    combatUI.ChangeActionVisualPos();
                   
                }
                else
                {
                    combatUI.HideActionVisual(1);
                    combatManager.UpdateCombatState(CombatState.EnemyTurn);
                    combatManager.attackType = AttackType.None;
                    combatManager.currentUnitInTurn = combatManager.unitsInCombat[2];
                    combatUI.playerActionUi.SetActive(false);

                }
                    
                
            }
        }
        else if (combatManager.attackType == AttackType.Attack && combatManager.state == CombatState.PlayerTurn)
        {
            highlight.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                if (combatManager.currentUnitInTurn == combatManager.unitsInCombat[0] && combatManager.player.teamMate)
                {
                    combatUI.ChangeActionVisualPos();
                    combatManager.currentUnitInTurn = combatManager.unitsInCombat[1];
                }
                else
                {
                    combatManager.state = CombatState.EnemyTurn;
                }
            }
        }


    }

    private void OnMouseExit()
    {
        highlight.SetActive(false);
    }


}
