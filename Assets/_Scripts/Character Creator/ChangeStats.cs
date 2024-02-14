using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeStats : MonoBehaviour
{
    public List<TMP_Text> statsList;
    public List<int> minStatValue;
    int remainingPoints;

    private void Start()
    {
        SetMinStatValue();
    }
    public void PointsAdd(int statIndex)
    {
        remainingPoints = int.Parse(statsList[0].text);

        if (remainingPoints == 0) { return; }

        int statValue = int.Parse(statsList[statIndex].text);
        statValue++;
        remainingPoints--;
        statsList[0].text = remainingPoints.ToString();
        statsList[statIndex].text = statValue.ToString();

    }
    public void PointsRemove(int statIndex)
    {
        remainingPoints = int.Parse(statsList[0].text);

        if (minStatValue[statIndex] == int.Parse(statsList[statIndex].text)) { return; }

        int statValue = int.Parse(statsList[statIndex].text);
        statValue--;
        remainingPoints++;
        statsList[0].text = remainingPoints.ToString();
        statsList[statIndex].text = statValue.ToString();

    }

    void SetMinStatValue()
    {
        for (int i = 1; i < statsList.Count; i++)
        {
            minStatValue[i] = int.Parse(statsList[i].text);
        }
    }
}
