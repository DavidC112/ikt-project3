using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key2 : MonoBehaviour
{
    public int key2;
    public GameObject key;
    public bool player;
    void Start()
    {
        key2 = PlayerPrefs.GetInt("key2");
        if (key2 == 1)
        {
            Destroy(key);
        }

    }

    void Update()
    {
        Pick();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Test"))
        {
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            player = true;
        }
    }

    public void Pick()
    {
        if (player && Input.GetKeyDown("e"))
        {
            key2 = 1;
            Destroy(key);
            PlayerPrefs.SetInt("key2", key2);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player = false;
        collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
