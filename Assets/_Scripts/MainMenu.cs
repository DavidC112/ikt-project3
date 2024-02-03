using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartButton()
    {

        SceneManager.LoadScene("CharacterCreaterMenu");
    }
    public void QuitButton()
    {
        // The Application.Quit call is ignored in the Editor.
        Application.Quit();
    }
}
