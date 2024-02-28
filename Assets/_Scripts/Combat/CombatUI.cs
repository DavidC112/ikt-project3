using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUI : MonoBehaviour
{
    //Spagettikód :smiling_face_with_tear: :smiling_face_with_tear: :smiling_face_with_tear: :smiling_face_with_tear: :smiling_face_with_tear: :smiling_face_with_tear: 


    [SerializeField] public GameObject playerActionUi;
    public List<GameObject> playerPosition;
    [SerializeField]private GameObject _playerPrefab;
    public CombatManager combatManager;
    private GameObject _canvas;
    public bool _teammate;
    private void Start()
    {
        _teammate = _playerPrefab.GetComponent<Unit>().player.isTeamMate;
        


    }

    public void ShowActionVisuals(CombatState state)
    {

        if (state == CombatState.PlayerTurn && combatManager.currentUnitInTurn == combatManager.unitsInCombat[0])
        {
            _canvas = combatManager.currentUnitInTurn.transform.GetChild(0).gameObject;
            if (combatManager.player.isTeamMate == false)
            {
                playerActionUi.transform.position = playerPosition[0].transform.position;
            }
            else
            {
                playerActionUi.transform.position = playerPosition[1].transform.position;
            }

            //playerActionUi.SetActive(true);
            _canvas.transform.GetChild(0).gameObject.SetActive(true);
            _canvas.transform.GetChild(1).gameObject.SetActive(true);
        }
        
    }

   public void ChangeActionVisualPos()
    {
        _canvas = combatManager.currentUnitInTurn.transform.GetChild(1).gameObject;
        _canvas.transform.GetChild(0).gameObject.SetActive(true);
        _canvas.transform.GetChild(1).gameObject.SetActive(true);
    }

    public void HideActionVisual(int playerIndex)
    {
        _canvas = combatManager.currentUnitInTurn.transform.GetChild(playerIndex).gameObject;
        _canvas.transform.GetChild(0).gameObject.SetActive(false);
        _canvas.transform.GetChild(1).gameObject.SetActive(false);
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
