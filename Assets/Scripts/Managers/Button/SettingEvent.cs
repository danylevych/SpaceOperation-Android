using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


// +=========================================+
// |                                         |
// |   This script for the buttons in the    |
// |           OptionsMenu scene.            |
// |                                         |
// +=========================================+

public class SettingEvent : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider backMusic;
    [SerializeField] private Slider effectMusic;
    [SerializeField] private AudioSource button;
    [SerializeField] private GameObject loadingScene;


    private void Awake()
    {
        backMusic.value = PlayerPrefs.GetFloat("BackVolume", 1);
        effectMusic.value = PlayerPrefs.GetFloat("EffectVolume", 1);
    }

    // =========================== BackSound Slider =============================
    public void SetVolumeBackSound(float value)
    {
        mixer.SetFloat("BackVolume", Mathf.Log10(value) * 50);
        PlayerPrefs.SetFloat("BackVolume", value);
    }

    // ==========================================================================


    // ========================== EffectSound Slider ============================
    public void SetVolumeEffectSound(float value)
    {
        mixer.SetFloat("EffectVolume", Mathf.Log10(value) * 50);
        PlayerPrefs.SetFloat("EffectVolume", value);
    }
    // ==========================================================================

    // ==================== A Line Under Type Of Gunsight =======================
    public void SetsGunsight(int id)
    {
        PlayerPrefs.SetInt("TypeGunsight", id);
    }
    // ==========================================================================


    // ============================ ButtonSetting ===============================
    public void ButtonsSetting()
    {
        button.Play();
        Invoke(nameof(ButtonsSettingPriv), 0.3f);
    }

    private void ButtonsSettingPriv()
    {
        loadingScene.SetActive(true);
        SceneLoader.PreviousScene = "Option";
        SceneLoader.instance.LoadScene("ButtonsSetting");
    }
    // ==========================================================================


    // ============================ Back Button =================================
    public void Back()
    { 
        button.Play();
        Invoke(nameof(BackPriv), 0.3f);
    }

    private void BackPriv()
    {
        loadingScene.SetActive(true);
        SceneLoader.instance.LoadScene("MainMenu");
    }
    // ==========================================================================
}