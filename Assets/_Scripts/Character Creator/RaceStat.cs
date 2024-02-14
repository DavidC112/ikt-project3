using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaceStat : MonoBehaviour
{
    public Image playerSprite; 
    public RaceStats raceStats;
    public List<TMP_Text> statsList;
    public List<GameObject> statGameObjects;
    public List<int> minStatValue;
    private int remainingPoints;

    public void SetRaceStat()
    {
        remainingPoints = 10;
        statsList[0].text = remainingPoints.ToString();
        statsList[1].text = raceStats.vigPoint.ToString();
        statsList[2].text = raceStats.strPoint.ToString();
        statsList[3].text = raceStats.dexPoint.ToString();
        statsList[4].text = raceStats.endPoint.ToString();
        statsList[5].text = raceStats.intPoint.ToString();
        playerSprite.sprite = raceStats.raceSprite;  

        SetMinStatForOtherObjects(statGameObjects);
    }

    void SetMinStatForOtherObjects(List<GameObject> gameObjects)
    {
        foreach (var item in gameObjects)
        {
            for (int i = 1; i < minStatValue.Count; i++)
            {
                item.GetComponent<ChangeStats>().minStatValue[i] = minStatValue[i];
            }
        }
    }
}
