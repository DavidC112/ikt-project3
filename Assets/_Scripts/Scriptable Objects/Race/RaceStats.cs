using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "RaceStats")]
public class RaceStats : ScriptableObject
{
    //To Do: spritokat
    public int ID;
    public Sprite raceSprite;
    public int vigPoint;
    public int strPoint;
    public int dexPoint;
    public int endPoint;
    public int intPoint;  
}
