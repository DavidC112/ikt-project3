using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public static CombatUI combatUI;
    public static CombatManager combatManager;
    public static List<GameObject> damagableCharacter;

    void Start()
    {
        combatManager = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        combatUI = GameObject.Find("CombatUI").GetComponent<CombatUI>();
    }

    public static IEnumerator EnemyTurns()
    {   //valamit csinalnak az enemyk
        for (int i = 2; i < combatManager.unitsInCombat.Count; i++)
        {
            combatManager.currentUnitInTurn = combatManager.unitsInCombat[i];
            Unit currentUnit = combatManager.currentUnitInTurn.GetComponent<Unit>();
            int enemyDamage = (currentUnit.player.strength + currentUnit.player.dexterity + 15) / 8;
            //GameObject damagedCharacter = unitsInCombat[Random.Range(0, 2)];
            damagableCharacter = new();
            int rnd = Random.Range(0, damagableCharacter.Count);

            //foreach (var item in combatManager.unitsInCombat.Skip(-4))
            //{
            //    if (item.activeSelf == true)
            //    {
            //        damagableCharacter.Add(item);
            //    }
            //}
            for (int j = 0; j < 2; j++)
            {
                if (combatManager.unitsInCombat[j].activeSelf == true)
                {
                    damagableCharacter.Add(combatManager.unitsInCombat[j]);
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

            combatManager.CheckIfCombatEnds();

            yield return new WaitForSeconds(1);
        }
        //elit hibakezeles
        if (combatManager.unitsInCombat[0].activeSelf == true)
        {
            combatManager.currentUnitInTurn = combatManager.unitsInCombat[0];
        }
        else
        {
            combatManager.currentUnitInTurn = combatManager.unitsInCombat[1];
        }

        combatManager.UpdateCombatState(CombatState.PlayerTurn);

    }
}
