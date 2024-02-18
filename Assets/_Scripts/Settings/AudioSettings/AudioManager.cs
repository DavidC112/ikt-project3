using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("--------- AudioMixer ---------")]
    [SerializeField] private AudioMixer GEN;
    [SerializeField] private AudioMixer VFX;
    [SerializeField] private AudioMixer BGM;
    [Header("--------- Source ---------")]
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource musicSource;

    [Header("--------- Audios ---------")]
    public AudioClip MainMenu_VFX;
    public AudioClip MainMenu_General;
    public AudioClip MainMenu_BGM;

    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        float savedVolume = PlayerPrefs.GetFloat("BGMusicVolume");
        SetMusicVolume(savedVolume);
    }
    public void SetMusicVolume(float volume)
    {
        BGM.SetFloat("BGMusic", volume);
        PlayerPrefs.SetFloat("BGMusicVolume", volume);
    }   


    public void Start()
    {
        musicSource.clip = MainMenu_BGM;
        musicSource.Play();
    }


}
