using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] float sfxVolume, musicVolume;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }

        LoadMusicVolume();
        LoadSFXVolume();
    }

    private void Start()
    {
        ChangeMusicVolume(musicVolume);
        ChangeSFXVolumen(sfxVolume);
    }

    public void ChangeMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp(volume, 0.001f, 1);
        audioMixer.SetFloat("MusicVolume",Mathf.Log10 (musicVolume) * 20);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void ChangeSFXVolumen(float volume)
    {
        sfxVolume = Mathf.Clamp(volume, 0.001f, 1);
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(sfxVolume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadSFXVolume()
    {
        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            sfxVolume = PlayerPrefs.GetFloat("SFXVolume");
            ChangeSFXVolumen(sfxVolume);
        }
    }

    public void LoadMusicVolume()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            musicVolume = PlayerPrefs.GetFloat("MusicVolume");
            ChangeMusicVolume(musicVolume);
        }
    }

    public float GetMusic()
    {
        return musicVolume;
    }

    public float GetSFX()
    {
        return sfxVolume;
    }
}
