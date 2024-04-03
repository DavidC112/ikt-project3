using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject menuUI;


    void Start()
    {
        if (menuUI != null)
        {
            menuUI.SetActive(false);
        }
    }

    void Update()
    {
    }

    public void ToggleMenu(bool collided)
    {
        if (Input.GetKeyDown("e") && collided)
        {
            menuUI.SetActive(!menuUI.activeSelf);
        }
    }
}
