using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour
{
   
    [SerializeField] private Slider GEN_Slider;
    [SerializeField] private AudioMixer BGM;
    [SerializeField] private Slider SFX_Slider;
    [SerializeField] private Slider BGM_Slider;


    void Start()
    {
        BGM_Slider.value = PlayerPrefs.GetFloat("BGMusicVolume", 0.75f);
        SetMusicVolume();
    }
    public void SetMusicVolume()
    {
        float volume = BGM_Slider.value;
        BGM.SetFloat("BGMusic", volume);
        // Save the current volume to PlayerPrefs
        PlayerPrefs.SetFloat("BGMusicVolume", volume);
    }

}
