using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    public GameObject DialogPanel;
    public TMP_Text DialogText;
    public string[] dialogue;
    private int index;
    public GameObject continueBtn;
    public float wordSpeed;
    public bool PlayerIsClose;
    public Player player;
    public Button quit;
    public static bool conv;
    public static bool boss;

    private void Start()
    {
        if (CombatManager.bossDead == true && gameObject.tag == "boss")
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E) && PlayerIsClose)
        {
            conv = true;
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
            continueBtn.SetActive(false);
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
        other.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Test"))
        {
            PlayerIsClose = false;
            zeroText();
        }
        other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
            Debug.Log("No Köbambi :(");
        }

    }


    public void Treasure()
    {
        int treasure = PlayerPrefs.GetInt("treasure");
         if(treasure > 0)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    public void Csoves()
    {
        player.isTeamMate = true;
        Destroy(gameObject);
        Quit();
    }

    public void Quit()
    {
        conv = false;
    }

    public void BossFight()
    {
        boss = true;
        player.playerLocation = gameObject.transform.position;
        player.sceneToSpawnBack = SceneManager.GetActiveScene().name;

        SceneManager.LoadScene("Combat");
    }
}
