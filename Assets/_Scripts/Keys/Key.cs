using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public int key1;
    public GameObject key;
    public bool player;
    void Start()
    {
        key1 = PlayerPrefs.GetInt("key1");
        if (key1 == 1)
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
            key1 = 1;
            Destroy(key);
            PlayerPrefs.SetInt("key1", key1);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player = false;
        collision.gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
