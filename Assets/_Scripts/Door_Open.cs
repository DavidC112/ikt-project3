using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Open : MonoBehaviour
{

    public string sceneToload;
    public bool player = false;
    public  Vector2 playerPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Test"))
        {
            player = true;
            PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
            PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);
        }
    }
    void Update()
    {
        Doors();    
    }

   
    private void OnTriggerExit2D(Collider2D collision)
    {
            player = false;   
    }

    public void Doors()
    {
        if (Input.GetKeyDown("e") && player == true)
        {
            SceneManager.LoadScene(sceneToload);
        }
    }
}

