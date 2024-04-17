using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Loads to a specified scene
    public int key1, key2, MainKey;
    void Update()
    {
        key1 = PlayerPrefs.GetInt("key1");
        key2 = PlayerPrefs.GetInt("key2");
        MainKey = PlayerPrefs.GetInt("MainKey");
    }

    public void LoadSceneTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoadToBucka(string scenename)
    {
        if(key1 == 1 && key2 == 1 && MainKey == 0) 
        {
            SceneManager.LoadScene(scenename);
        }
    }

    public void LoadToTreasury()
    {
        if(MainKey == 1)
        {  
            SceneManager.LoadScene("BuckaTreasureScene"); 
        }
    }


    public void Quit()
    {
        Application.Quit();
    }

    public string sceneToload;
    public Vector2 playerPos;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPrefs.SetFloat("PlayerPosX", playerPos.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerPos.y);
        LoadToBucka(sceneToload);
        LoadToTreasury();
        SceneManager.LoadScene(sceneToload);
        
    }
}
