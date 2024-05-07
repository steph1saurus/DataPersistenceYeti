using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    private const string musicVolumeKey = "MusicVolume";
    private const string SFXVolumeKey = "SFXVolume";

    private void Start()
    {
        // Load saved volume levels from PlayerPrefs or use default value of 1.0
        float savedMusicVolume = PlayerPrefs.GetFloat(musicVolumeKey, 1.0f);
        SetMusicLevel(savedMusicVolume);

        float savedSFXVolume = PlayerPrefs.GetFloat(SFXVolumeKey, 1.0f);
        SetSFXLevel(savedSFXVolume);
    }

    public void SetMusicLevel(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        mixer.SetFloat("MusicVol", volume);

        // Save the volume level in PlayerPrefs
        PlayerPrefs.SetFloat(musicVolumeKey, sliderValue);
        PlayerPrefs.Save();
    }

    public void SetSFXLevel(float sliderValue)
    {
        float volume = Mathf.Log10(sliderValue) * 20;
        mixer.SetFloat("SFXVol", volume);

        // Save the volume level in PlayerPrefs
        PlayerPrefs.SetFloat(SFXVolumeKey, sliderValue);
        PlayerPrefs.Save();
    }

}
