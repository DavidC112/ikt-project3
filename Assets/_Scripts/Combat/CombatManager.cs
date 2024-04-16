using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombatManager : MonoBehaviour
{
    public GameObject characterPrefab;
    public Player player;
    public List<GameObject> playerPositions;
    public List<GameObject> enemyPosition;
    public List<GameObject> enemyPrefabList;
    public List<GameObject> unitsInCombat;
    public List<GameObject> aliveEnemys;
    public List<GameObject> alivePlayerUnit;
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
                Debug.Log("WIN");
                player.combat = true;
                SceneManager.LoadScene(player.sceneToSpawnBack);
                StopAllCoroutines();
                break;
            case CombatState.Lose:
                Debug.Log("LOSE");
                StopAllCoroutines();
                break;
        }
    }



    private void SpawnInUnits()
    {
        //Instantiate player;
        if (player.isTeamMate == false)
        {
            unitsInCombat[0] = Instantiate(characterPrefab, playerPositions[0].transform);
            unitsInCombat[0].gameObject.GetComponent<Animator>().runtimeAnimatorController = player.animation;
            unitsInCombat[1] = null;

            alivePlayerUnit.Add(unitsInCombat[0]);
        }
        else
        {
            unitsInCombat[0] = Instantiate(characterPrefab, playerPositions[1].transform);
            unitsInCombat[0].gameObject.GetComponent<Animator>().runtimeAnimatorController = player.animation;
            unitsInCombat[1] = Instantiate(player.teamMate, playerPositions[2].transform);

            alivePlayerUnit.Add(unitsInCombat[0]);
            alivePlayerUnit.Add(unitsInCombat[1]);
        }


        //Instantiate enemy(s)
        int enemyNumber = Random.Range(0, enemyPosition.Count);
        for (int i = 0; i < enemyNumber+1; i++) 
        {
            int enemyIndex = Random.Range(0, enemyPrefabList.Count);
            unitsInCombat.Add(Instantiate(enemyPrefabList[enemyIndex], enemyPosition[i].transform));
            aliveEnemys.Add(unitsInCombat[unitsInCombat.Count-1]);
        }

        currentUnitInTurn = unitsInCombat[0];
        UpdateCombatState(CombatState.PlayerTurn);
    }

    public CombatState CheckIfCombatEnds()
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
                        if (unitsInCombat[0].activeSelf == false && player.isTeamMate == false)
                        {
                            Debug.Log("Lose");
                            return CombatState.Lose;
                        }
                        if (player.isTeamMate && unitsInCombat[0].activeSelf == false && unitsInCombat[0].activeSelf == false)
                        {
                            Debug.Log("Lose");
                            return CombatState.Lose;
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
                            Debug.Log("Win");
                            return CombatState.Win;
                        }
                    }
                    break;
                    
            }
        }
        if (currentUnitInTurn == unitsInCombat[0] || currentUnitInTurn == unitsInCombat[1])
        {
            return CombatState.PlayerTurn;
        }
        else
        {
            return CombatState.EnemyTurn;
        }
        
    }

    public IEnumerator EnemyTurns()
    {   //valamit csinalnak az enemyk
        //for (int i = 2; i < unitsInCombat.Count; i++)
        //{
        //    currentUnitInTurn = unitsInCombat[i];
        //    if (currentUnitInTurn.activeSelf == true || state != CombatState.Lose || state != CombatState.Win)
        //    {
        //        Unit currentUnit = currentUnitInTurn.GetComponent<Unit>();
        //        int enemyDamage = (currentUnit.player.strength + currentUnit.player.dexterity + 15) / 8;

        //        List<GameObject> damagableCharacter = new();

        //        for (int j = 0; j < 2; j++)
        //        {
        //            if (unitsInCombat[j].activeSelf == true)
        //            {
        //                damagableCharacter.Add(unitsInCombat[j]);
        //            }
        //            if(player.isTeamMate == false)
        //            {
        //                j++;
        //            }
        //        }

        //        if (damagableCharacter.Count == 0)
        //        {
        //            UpdateCombatState(CombatState.Lose);
        //            yield return 0;
        //        }
        //        else
        //        {
        //            int rnd = Random.Range(0, damagableCharacter.Count);
        //            Debug.Log(rnd + "indexu playercharacter");

        //            combatUI.VisalStateChange(true);

        //            if (damagableCharacter[rnd].GetComponent<Unit>().TakeDamage(enemyDamage))
        //            {
        //                damagableCharacter[rnd].SetActive(false);
        //            }
        //            damagableCharacter[rnd].GetComponent<Unit>().SetHP(damagableCharacter[rnd].GetComponent<Unit>().currentHealth);

        //            combatUI.VisalStateChange(false);

        //            yield return new WaitForSeconds(1);
        //        }
        //    }


        //}
        if (state == CombatState.Lose || state == CombatState.Win)
        {
            yield break;
        }

        for (int i = 0; i < aliveEnemys.Count; i++)
        {
            currentUnitInTurn = aliveEnemys[i];

            Unit currentUnit = currentUnitInTurn.GetComponent<Unit>();
            int enemyDamage = (currentUnit.player.strength + currentUnit.player.dexterity + 15) / 8;

            if (alivePlayerUnit.Count == 0)
            {
                UpdateCombatState(CombatState.Lose);
                yield return 0;
            }
            else
            {
                int rnd = Random.Range(0, alivePlayerUnit.Count);
                if (alivePlayerUnit.Count == 1)
                {
                    rnd = 0;
                }
                Debug.Log(rnd + "indexu playercharacter");

                combatUI.VisalStateChange(true);

                if (alivePlayerUnit[rnd].GetComponent<Unit>().TakeDamage(enemyDamage))
                {
                    UnalivePlayerUnit(rnd);
                }
                alivePlayerUnit[rnd].GetComponent<Unit>().SetHP(alivePlayerUnit[rnd].GetComponent<Unit>().currentHealth);

                combatUI.VisalStateChange(false);

                yield return new WaitForSeconds(1);
            }
        }

        if (unitsInCombat[0].activeSelf == true) 
        {
            currentUnitInTurn = unitsInCombat[0];
        }
        else if (unitsInCombat[1].activeSelf == true && unitsInCombat != null)
        {
            currentUnitInTurn = unitsInCombat[1];
        }
        UpdateCombatState(CheckIfCombatEnds());
    }
    void UnalivePlayerUnit(int rnd)
    {
        alivePlayerUnit[rnd].SetActive(false);
        for (int i = 0; i < alivePlayerUnit.Count; i++)
        {
            if (alivePlayerUnit[i] == alivePlayerUnit[rnd])
            {
                alivePlayerUnit.RemoveAt(i);
            }
        }
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
