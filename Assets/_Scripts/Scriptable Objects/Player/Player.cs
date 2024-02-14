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
    public Weapons meleeWeapon;
}
