using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBtn : MonoBehaviour
{
    public AudioSource soundPlayer;
    public void PlayThisSoundEffect()
    {
        soundPlayer.Play();
    }
}
