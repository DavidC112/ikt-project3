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
    public RuntimeAnimatorController animation;
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
        player.animation = RaceStat.animaton;
        player.playerLocation = new Vector2(3.04f, 0.25f);

        player.isTeamMate = false;

        PlayerPrefs.SetInt("gold", 20);
        PlayerPrefs.SetInt("kobambi", 0);
        PlayerPrefs.SetInt("meggypalesz", 0);
        PlayerPrefs.SetInt("abszint", 0);
        PlayerPrefs.SetFloat("PlayerPosX", 2.99f);
        PlayerPrefs.SetFloat("PlayerPosY", -0.7f);
        PlayerPrefs.SetInt("key1", 0);
        PlayerPrefs.SetInt("key2", 0);
        PlayerPrefs.SetInt("treasure", 0);
        SceneManager.LoadScene("TownHall");
        PlayerPrefs.SetInt("MainKey", 0);

    }
    string GetNameFromInputField()
    {
        return inputField.text;
    }
}
