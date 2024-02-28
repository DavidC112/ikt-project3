using System;
using System.Collections;
using System.Collections.Generic;
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
    public static event Action<CombatState> OnCombatStateChange;
    public static event Action<AttackType> OnAttackStateChange;

    private void Start()
    {
        ///playerStats = characterPrefab.GetComponent<Unit>().player;
        
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
                combatUI.ShowActionVisuals(CombatState.PlayerTurn);
                break;
            case CombatState.EnemyTurn:
                StartCoroutine(EnemyTurns());
                break;
            case CombatState.Win:
                break;
            case CombatState.Lose:
                break;
        }

        OnCombatStateChange?.Invoke(newState);
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
        int enemyNumber = UnityEngine.Random.Range(0, 3);
        for (int i = 0; i < enemyNumber+1; i++) 
        {
            int enemyIndex = UnityEngine.Random.Range(0, 2);
            //unitsInCombat[i+2] = Instantiate(enemyPrefabList[enemyIndex], enemyPosition[i].transform);
            unitsInCombat.Add(Instantiate(enemyPrefabList[enemyIndex], enemyPosition[i].transform));
        }

        currentUnitInTurn = unitsInCombat[0];
        UpdateCombatState(CombatState.PlayerTurn);
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
