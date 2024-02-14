using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeClass : MonoBehaviour
{
    public List<GameObject> classButton;
    public TMP_Text classText;
    [HideInInspector]
    public string[] classArray = { "Warrior", "Barabarian", "Ranger", "Wizard" };
    //public Sprite[] weaponSprites;
    public Weapons[] classObjects;
    public static Weapons selectedClass;
    public Image weaponImage; 
    public int classArrayIndex = 0;

    private void Start()
    {
        selectedClass = classObjects[classArrayIndex];
    }

    public void ChangeClassOfPlayer(string button)
    {
        SetArrayIndex(classButton);
        switch (button)
        {
            case "left":
                if (classArrayIndex == 0)
                {
                    classArrayIndex = 3;
                    classText.text = classArray[classArrayIndex];
                    weaponImage.sprite = classObjects[classArrayIndex].weaponSprite;
                    selectedClass = classObjects[classArrayIndex];
                    SetArrayIndex(classButton);
                    return;
                }
                classArrayIndex--;
                classText.text = classArray[classArrayIndex];
                weaponImage.sprite = classObjects[classArrayIndex].weaponSprite;
                selectedClass = classObjects[classArrayIndex];
                SetArrayIndex(classButton);
                break;
            case "right":
                if (classArrayIndex == 3)
                {
                    classArrayIndex = 0;
                    classText.text = classArray[classArrayIndex];
                    weaponImage.sprite = classObjects[classArrayIndex].weaponSprite;
                    selectedClass = classObjects[classArrayIndex];
                    SetArrayIndex(classButton);
                    return;
                }
                classArrayIndex++;
                classText.text = classArray[classArrayIndex];
                selectedClass = classObjects[classArrayIndex];
                weaponImage.sprite = classObjects[classArrayIndex].weaponSprite;
                SetArrayIndex(classButton);
                break;
        }
    }
    void SetArrayIndex(List<GameObject> gameObjects)
    {
        foreach (var item in gameObjects)
        {
            item.GetComponent<ChangeClass>().classArrayIndex = classArrayIndex;
        }
    }
}
