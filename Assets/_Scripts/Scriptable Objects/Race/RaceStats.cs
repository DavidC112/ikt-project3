using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "RaceStats")]
public class RaceStats : ScriptableObject
{
    public Sprite raceSprite;
    public RuntimeAnimatorController raceAnimation;
    public int vigPoint;
    public int strPoint;
    public int dexPoint;
    public int endPoint;
    public int intPoint;  
}
