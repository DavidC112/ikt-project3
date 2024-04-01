using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    public Shop Shop;
    public bool player = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Test"))
        {
            player = true;
        }
    }
    void Update()
    {
        Shop.ToggleMenu(player);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Test"))
        {
            player = false;
            Shop.menuUI.SetActive(false);
        }
    }

}