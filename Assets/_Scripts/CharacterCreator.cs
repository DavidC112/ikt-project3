using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using System.Net.Http.Headers;
using System;

public class CharacterCreator : MonoBehaviour
{
    public RaceStats raceStats;

    public TMP_Text vigText;
    public TMP_Text strText;
    public TMP_Text dexText;
    public TMP_Text endText;
    public TMP_Text intText;
    public TMP_Text pointsText;

    public int allocatablePoints;
    int igen = 1;

    private void Update()
    {
        //allocatablePoints = int.Parse(pointsText.text);
    }
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void PlayButton()
    {
        Debug.Log("Play");
        //SceneManager.LoadScene("Game");
    }

    public void RaceStat()
    {
        allocatablePoints = 10;
        pointsText.text = allocatablePoints.ToString();
        vigText.text = raceStats.vigPoint.ToString();    
        strText.text = raceStats.strPoint.ToString();
        dexText.text = raceStats.dexPoint.ToString();
        endText.text = raceStats.endPoint.ToString();
        intText.text = raceStats.intPoint.ToString();
    }    

    public void PointsAdd(string attribute)
    {
        if (allocatablePoints == 0)
        {
            Debug.Log("igen");
            return; 
        }

        
            switch (attribute)
            {
                case "vig":
                    int vigValue = Convert.ToInt32(vigText.text);
                    vigValue++;
                    allocatablePoints -= igen;
                    pointsText.text = allocatablePoints.ToString();
                    vigText.text = vigValue.ToString();
                    return;
                case "str":
                    int strValue = Convert.ToInt32(strText.text);
                    strValue++;
                    allocatablePoints--;
                    pointsText.text = allocatablePoints.ToString();
                    strText.text = strValue.ToString();
                    break;
                case "dex":
                    int dexValue = Convert.ToInt32(dexText.text);
                    dexValue++;
                    allocatablePoints--;
                    pointsText.text = allocatablePoints.ToString();
                    dexText.text = dexValue.ToString();
                    break;
                case "end":
                    int endValue = Convert.ToInt32(endText.text);
                    endValue++;
                    allocatablePoints--;
                    pointsText.text = allocatablePoints.ToString();
                    endText.text = endValue.ToString();
                    break;
                case "int":
                    int intValue = Convert.ToInt32(intText.text);
                    intValue++;
                    allocatablePoints--;
                    pointsText.text = allocatablePoints.ToString();
                    intText.text = intValue.ToString();
                    break;
            }
    }
    public void PointsRemove(string attribute)
    {
        if (allocatablePoints < 0)
        { return; }
        
        

        switch (attribute)
        {
            case "vig":
                int vigValue = Convert.ToInt32(vigText.text);
                vigValue--;
                allocatablePoints += igen;
                pointsText.text = allocatablePoints.ToString();
                vigText.text = vigValue.ToString();
                break;
            case "str":
                int strValue = Convert.ToInt32(strText.text);
                strValue--;
                allocatablePoints++;
                pointsText.text = allocatablePoints.ToString();
                strText.text = strValue.ToString();
                break;
            case "dex":
                int dexValue = Convert.ToInt32(dexText.text);
                dexValue--;
                allocatablePoints++;
                pointsText.text = allocatablePoints.ToString();
                dexText.text = dexValue.ToString();
                break;
            case "end":
                int endValue = Convert.ToInt32(endText.text);
                endValue--;
                allocatablePoints++;
                pointsText.text = allocatablePoints.ToString();
                endText.text = endValue.ToString();
                break;
            case "int":
                int intValue = Convert.ToInt32(intText.text);
                intValue--;
                allocatablePoints++;
                pointsText.text = allocatablePoints.ToString();
                intText.text = intValue.ToString();
                break;
        }
    }
}
