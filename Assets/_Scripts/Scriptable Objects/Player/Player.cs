using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats")]
public class Player : ScriptableObject
{
    public Sprite sprite;

    public string playerName;
    public int vigor;
    public int strength;
    public int dexterity;
    public int endurance;
    public int intelligence;
    //public int maxHealth;
    //public int currentHealth;
    //public int maxPP;
    //public int currentPP;
    
    public Weapons meleeWeapon;

    public bool isTeamMate = false;
    public GameObject teamMate;
}
