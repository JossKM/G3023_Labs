using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioMixer mainMixer;
    private string musicVolumeParameter = "MusicVolume";
    private string musicLowpassParameter = "MusicLowpassCutoff";

    Vector2 volumeRangeMinMax_dB = new Vector2(-80, 0);

    private AudioManager instance = null;
    public AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<AudioManager>();
            }
            return instance;
        }
        private set { }
    }

    // When the menu is opened or closed
    public void OnMenuStateChange(bool isOpen)
    {
        if(isOpen)
        {
            mainMixer.SetFloat(musicLowpassParameter, 500);
        } else
        {
            mainMixer.SetFloat(musicLowpassParameter, 100000);
        }
    }

    //Set volume from 0 to 1
    public void SetMusicVolume(float normalizedVolume)
    {
        if(normalizedVolume == 0)
        {
            musicSource.Pause();
        } else
        {
            musicSource.UnPause();
        }

        float volume_dB = Mathf.Lerp(volumeRangeMinMax_dB.x, volumeRangeMinMax_dB.y, normalizedVolume);
        mainMixer.SetFloat(musicVolumeParameter, volume_dB);
    }

    //Get volume normalized from 0 to 1
    public float GetMusicVolume()
    {
        mainMixer.GetFloat(musicVolumeParameter, out float volume_dB);
        float volume_normalized = Mathf.InverseLerp(volumeRangeMinMax_dB.x, volumeRangeMinMax_dB.y, volume_dB);
        return volume_normalized;
    }

    void Start()
    {
        //Check to make sure only one instance of AudioManager is allowed to exist in the scene,
        //even if loading another scene with AudioManager on it
        if(Instance == this) // Am I the original????
        {
            DontDestroyOnLoad(this); // Make me immortal!
        } else
        {
            Destroy(this.gameObject); // I am not the original. I must be destroyed...
        }
    }
}
