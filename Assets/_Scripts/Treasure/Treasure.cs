using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Treasure : MonoBehaviour
{
    public Shop Shop;
    public bool player = false;
    public int treasure;

    void Start()
    {
        treasure = PlayerPrefs.GetInt("treasure");
        if(treasure == 1)
        { Destroy(gameObject); }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Test"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
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
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            player = false;
            Shop.menuUI.SetActive(false);
        }
    }

    public void Return()
    {
        Shop.menuUI.SetActive(false );
        Destroy(gameObject);
        treasure = 1;
        PlayerPrefs.SetInt("treasure", treasure);
    }
    
    public void Keep()
    {
        SceneManager.LoadScene("EndScene");
    }

}
