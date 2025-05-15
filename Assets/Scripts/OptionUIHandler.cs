using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUIHandler : MonoBehaviour
{
    [SerializeField] Slider sfxSlider, musicSlider;

    private void Start()
    {
        sfxSlider.onValueChanged.AddListener(delegate
        {
            AudioManager.Instance.ChangeSFXVolumen(sfxSlider.value);    
        });

        musicSlider.onValueChanged.AddListener(delegate
        {
            AudioManager.Instance.ChangeMusicVolume(musicSlider.value);
        });
    }

    public void OnEnable()
    {
        musicSlider.value = AudioManager.Instance.GetMusic();
        sfxSlider.value = AudioManager.Instance.GetSFX();
    }
}
