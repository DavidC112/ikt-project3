using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadToCombat : MonoBehaviour
{

    [SerializeField] private Player player;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private LayerMask bushes;
    // Start is called before the first frame update
    void Update()
    {
        
    }
    
    public void CheckForEncounters()
    {
        float chance = Random.Range(50, 151) * Time.fixedDeltaTime;

        //Debug.Log(Time.fixedDeltaTime);
        if (Physics2D.OverlapCircle(playerGameObject.transform.position,0.2f, bushes) != null)
        {
            if (chance == 1 && chance > 0)
            {
                player.playerLocation = playerGameObject.transform.position;
                player.sceneToSpawnBack = SceneManager.GetActiveScene().name;

                SceneManager.LoadScene("Combat");
            }
        }
    }
}
