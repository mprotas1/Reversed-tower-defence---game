using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        SetMaxAndCurrentValue();
    }

    private void SetMaxAndCurrentValue()
    {
        string sliderName = gameObject.name;

        float volume = 0.0f;

        switch (sliderName)
        {
            case "MasterSlider":
                SoundManager.Instance.Mixer.GetFloat("MasterVolume", out volume);
                //slider.maxValue = volume;
                //slider.value = volume;
                slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMasterVolume(val));
                break;
            case "MusicSlider":
                SoundManager.Instance.Mixer.GetFloat("MusicVolume", out volume);
                //slider.maxValue = volume;
                //slider.value = volume;
                slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));
                break;
            case "SfxSlider":
                SoundManager.Instance.Mixer.GetFloat("SfxVolume", out volume);
                //slider.maxValue = volume;
                //slider.value = volume;
                slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeSfxVolume(val));
                break;
        }

        
    }
}
