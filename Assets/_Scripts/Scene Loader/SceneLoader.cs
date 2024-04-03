using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Loads to a specified scene
    public void LoadSceneTo(string scene)
    {
        SceneManager.LoadScene(scene);
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
        SceneManager.LoadScene(sceneToload);
    }
}
