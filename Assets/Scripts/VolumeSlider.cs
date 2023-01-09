using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start function of slider...");
        SetMaxAndCurrentValue();

        SceneManager.sceneLoaded += SetSliderValueOnLevelChange;
    }

    private void SetMaxAndCurrentValue()
    {
        string sliderName = gameObject.name;

        // just a mock variable to be used later on code...
        float volume = 0.0f;

        switch (sliderName)
        {
            case "MasterSlider":
                SoundManager.Instance.Mixer.GetFloat("MasterVolume", out volume);
                slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
                break;
            case "MusicSlider":
                SoundManager.Instance.Mixer.GetFloat("MusicVolume", out volume);
                slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
                break;
            case "SfxSlider":
                SoundManager.Instance.Mixer.GetFloat("SfxVolume", out volume);
                slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeSfxVolume(val));
                float sliderValue = slider.value;
                PlayerPrefs.SetFloat("sfxSliderValue", sliderValue);
                Debug.Log(PlayerPrefs.GetFloat("sliderValue"));
                break;
        }
    }

    private void SetSliderValueOnLevelChange(Scene scene, LoadSceneMode mode)
    {
        if(scene.name.Equals("Menu"))
        {
            Debug.Log("Loaded menu scene");
            SoundManager.Instance.Mixer.GetFloat("MasterVolume", out float volume);
            volume = Mathf.Log10(volume) * 20;
            slider.value = volume;
        }
    }
}
