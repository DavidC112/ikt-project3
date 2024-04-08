using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetPlayerStats : MonoBehaviour
{
    public TMP_InputField inputField;
    public Player player;
    public List<TMP_Text> statsList;

    public void SetPlayerGameObjectStats()
    {
        //TODO: Valami felugro ablak, hogy kell beírni nevet
       if (GetNameFromInputField() == "")
       {
            Debug.Log("Kell Nev");
            return; 
        }
        
        player.playerName = GetNameFromInputField();
        player.vigor = int.Parse(statsList[1].text);
        player.strength = int.Parse(statsList[2].text);
        player.dexterity = int.Parse(statsList[3].text);
        player.endurance = int.Parse(statsList[4].text);
        player.intelligence = int.Parse(statsList[5].text);
        player.meleeWeapon = ChangeClass.selectedClass;
        PlayerPrefs.SetInt("gold", 20);

        SceneManager.LoadScene("TownHall");
    }
    string GetNameFromInputField()
    {
        return inputField.text;
    }
}
