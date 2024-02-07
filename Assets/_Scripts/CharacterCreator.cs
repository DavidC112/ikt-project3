using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using Unity.VisualScripting;

public class CharacterCreator : MonoBehaviour
{
    public void BackButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void PlayButton()
    {
        Debug.Log("Play");
        //SceneManager.LoadScene("Game");
    }
}
