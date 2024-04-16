using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPlayer : MonoBehaviour
{
    private float x, y;
    [SerializeField ]private Player player;
    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Test");
        if (player != null && player.combat)
        {
            playerObj.transform.position = player.playerLocation;
            player.combat = false;
        }
        else
        {
            x = PlayerPrefs.GetFloat("PlayerPosX");
            y = PlayerPrefs.GetFloat("PlayerPosY");
            Debug.Log(x + " " + y);
            playerObj.transform.position = new Vector2(x, y);
        }
        gameObject.GetComponent<Animator>().runtimeAnimatorController = player.animation;
    }
}
