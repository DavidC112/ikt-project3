using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        int enemyNumber = Random.Range(0, enemyPosition.Count);
        for (int i = 0; i < enemyNumber+1; i++) 
        {
            int enemyIndex = Random.Range(0, enemyPrefabList.Count);
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
                        //Gatya kód
                        if (unitsInCombat[0].activeSelf == false && player.isTeamMate == false)
                        {
                            Debug.Log("what");
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
    {   //valamit csinalnak az enemyk
        Debug.Log(unitsInCombat.Count);
        for (int i = 2; i < unitsInCombat.Count; i++)
        {
            currentUnitInTurn = unitsInCombat[i];
            Unit currentUnit = currentUnitInTurn.GetComponent<Unit>();
            int enemyDamage = (currentUnit.player.strength + currentUnit.player.dexterity + 15) / 8;
            //GameObject damagedCharacter = unitsInCombat[Random.Range(0, 2)];
            List<GameObject> damagableCharacter = new();
            int rnd = Random.Range(0, damagableCharacter.Count);

            foreach (var item in unitsInCombat.Skip(-4))
            {
                if (item.activeSelf == true)
                {
                    damagableCharacter.Add(item);
                }
            }

            combatUI.VisalStateChange(true);

            if (damagableCharacter[rnd].GetComponent<Unit>().TakeDamage(enemyDamage))
            {
                damagableCharacter[rnd].SetActive(false);
            }
            Debug.Log("Enemy Turn");
            damagableCharacter[rnd].GetComponent<Unit>().SetHP(damagableCharacter[rnd].GetComponent<Unit>().currentHealth);

            combatUI.VisalStateChange(false);

            CheckIfCombatEnds();

            yield return new WaitForSeconds(1);
        }
        //elit hibakezeles
        if (unitsInCombat[0].activeSelf == true) 
        {
            currentUnitInTurn = unitsInCombat[0];
        }
        else
        {
            currentUnitInTurn = unitsInCombat[1];
        }
        
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
