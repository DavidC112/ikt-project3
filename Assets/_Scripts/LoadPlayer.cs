using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    private float x, y;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Test");
        x = PlayerPrefs.GetFloat("PlayerPosX");
        y = PlayerPrefs.GetFloat("PlayerPosY");
        Debug.Log(x + " " + y);
        player.transform.position = new Vector2(x, y);
    }

    void Update()
    {
        
    }
}
