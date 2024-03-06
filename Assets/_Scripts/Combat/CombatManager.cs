using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Build;
using UnityEngine;


public class CombatManager : MonoBehaviour
{
    public GameObject characterPrefab;
    public Player player;
    public List<GameObject> playerPositions;
    public List<GameObject> enemyPosition;
    public List<GameObject> enemyPrefabList;
    public List<GameObject> unitsInCombat;
    public GameObject currentUnitInTurn;
    public CombatUI combatUI;
    public static CombatManager instance;
    public CombatState state;
    public AttackType attackType;

    private void Start()
    {
        SpawnInUnits();
        UpdateCombatState(CombatState.PlayerTurn);

    }
    private void Awake()
    {
        instance = this;
    }

    public void UpdateCombatState(CombatState newState)
    {
        state = newState;

        switch (newState)
        {
            case CombatState.SpawningUnits:
                
                break;
            case CombatState.PlayerTurn:
                combatUI.VisalStateChange(true);
                break;
            case CombatState.EnemyTurn:
                StartCoroutine(EnemyTurns());
                break;
            case CombatState.Win:
                Debug.Log("you have won");
                break;
            case CombatState.Lose:
                break;
        }
    }



    private void SpawnInUnits()
    {
        //Instantiate player;
        if (player.isTeamMate == false)
        {
            unitsInCombat[0] =Instantiate(characterPrefab, playerPositions[0].transform);
            unitsInCombat[1] = null;
        }
        else
        {
            unitsInCombat[0] = Instantiate(characterPrefab, playerPositions[1].transform);
            unitsInCombat[1] = Instantiate(player.teamMate, playerPositions[2].transform);
        }


        //Instantiate enemy(s)
        int enemyNumber = UnityEngine.Random.Range(0, enemyPosition.Count);
        for (int i = 0; i < enemyNumber+1; i++) 
        {
            int enemyIndex = UnityEngine.Random.Range(0, enemyPrefabList.Count);
            unitsInCombat.Add(Instantiate(enemyPrefabList[enemyIndex], enemyPosition[i].transform));
        }

        currentUnitInTurn = unitsInCombat[0];
        UpdateCombatState(CombatState.PlayerTurn);
    }

    public void CheckIfCombatEnds()
    {
        for (int i = 0; i < 2; i++)
        {
            int n = 0;
            switch (i)
            {
                // Checks if all player character died
                case 0:
                    for (int j = 0; j < 2; j++)
                    {
                        //Gatya k�d
                        if (unitsInCombat[0].activeSelf == false && player.isTeamMate == false)
                        {
                            UpdateCombatState(CombatState.Lose);
                            return;
                        }
                        else if (player.isTeamMate)
                        {
                            if(unitsInCombat[j].activeSelf == false)
                                n++;
                        }
                        if (n == 2)
                        {
                            
                            UpdateCombatState(CombatState.Lose);
                        }
                    }
                    break;
                // Checks if all enemy died
                case 1:
                    foreach (var enemy in unitsInCombat.Skip(2))
                    {
                        if(enemy.activeSelf == false)
                        {
                            n++;
                        }
                        if(n == unitsInCombat.Count - 2)
                        {
                            UpdateCombatState(CombatState.Win);
                        }
                    }
                    break;
                    
            }
        }
    }

    public IEnumerator EnemyTurns()
    {   //valamit majd csinalnak az enemyk
        Debug.Log("Enemy Turn");
        yield return new WaitForSeconds(1);
        currentUnitInTurn = unitsInCombat[0]; 
        UpdateCombatState(CombatState.PlayerTurn);

    }
}
public enum CombatState
{
    SpawningUnits,
    PlayerTurn,
    EnemyTurn,
    Win,
    Lose
}

public enum AttackType
{
    None,
    Attack,
    Ability
}
