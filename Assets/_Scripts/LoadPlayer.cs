using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    private float x, y;
    void Start()
    {
        x = PlayerPrefs.GetFloat("PlayerPosX");
        y = PlayerPrefs.GetFloat("PlayerPosY");
        Debug.Log(x + " " + y);
        GameObject player = GameObject.FindGameObjectWithTag("Test");
        player.transform.position = new Vector2(x, y);
    }

    void Update()
    {
        
    }
}
