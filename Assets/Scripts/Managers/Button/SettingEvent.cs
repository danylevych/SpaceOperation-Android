using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SettingEvent : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider backMusic;
    [SerializeField] private Slider effectMusic;
    [SerializeField] private AudioSource button;


    private void Awake()
    {
        backMusic.value = PlayerPrefs.GetFloat("BackVolume", 1);
        effectMusic.value = PlayerPrefs.GetFloat("EffectVolume", 1);
    }

    public void SetVolumeBackSound(float value)
    {
        mixer.SetFloat("BackVolume", Mathf.Log10(value) * 50);
        PlayerPrefs.SetFloat("BackVolume", value);
    }

    public void SetVolumeEffectSound(float value)
    {
        mixer.SetFloat("EffectVolume", Mathf.Log10(value) * 50);
        PlayerPrefs.SetFloat("EffectVolume", value);
    }

    public void SetsGunsight(int id)
    {
        PlayerPrefs.SetInt("TypeGunsight", id);
    }
}
