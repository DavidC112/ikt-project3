using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;


public class PlayerInteract : MonoBehaviour
{
    public GameObject DialogPanel;
    public TMP_Text DialogText;
    public string[] dialogue;
    private int index;
    public Button buy;

    public GameObject continueBtn;
    public float wordSpeed;
    public bool PlayerIsClose;
    public Player player;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && PlayerIsClose)
        {
            if (DialogPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                DialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if (DialogText.text == dialogue[index])
        {
            continueBtn.SetActive(true);
        }
        
    }
    public void zeroText()
    {
        DialogText.text = "";
        index= 0;
        DialogPanel.SetActive(false);
    }
    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            DialogText.text+= letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }
    public void NextLine()
    {
        continueBtn.SetActive(false);

        if (index< dialogue.Length-1)
        {
            index++;
            DialogText.text = "";
            StartCoroutine(Typing());
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Test"))
        {
            PlayerIsClose = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Test"))
        {
            PlayerIsClose = false;
            zeroText();
        }

    }

    public void Gift()
    {
        int kobambi = PlayerPrefs.GetInt("kobambi");

        if (kobambi > 0)
        {
            kobambi--;
            PlayerPrefs.SetInt("kobambi", kobambi);
            Debug.Log($"Köbambi{kobambi}");
            Csoves();
        }
        else
        {
            buy.gameObject.SetActive(true);
        }

    }

    public void Csoves()
    {
        player.isTeamMate = true;
    }     
}
