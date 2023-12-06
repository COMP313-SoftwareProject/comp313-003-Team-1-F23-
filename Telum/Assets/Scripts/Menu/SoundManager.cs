using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] AudioMixer masterMixer;
    private float localValue = 0;

    private void Start()
    {
        SetVolume(PlayerPrefs.GetFloat("SaveMasterVolume", 0.75f));
    }

    public void SetVolume(float value)
    {
        if (value < 0.001f)
        {
            value = 0.001f;
        }
        localValue = value;

        RefreshSlider(value);
        PlayerPrefs.SetFloat("SaveMasterVolume", value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }

    public void SetVolumeFromSlider()
    {
        if (slider != null)
        {
            SetVolume(slider.value);
            PlayerPrefs.Save();
        }
    }

    public void RefreshSlider(float value)
    {
        if (slider != null)
        {
            slider.value = value;
        }
    }

    public void resetSlider(Slider newSlider)
    {
        if (slider == null)
        {
            slider = newSlider;
            Debug.Log(localValue);
            RefreshSlider(localValue);
            slider.onValueChanged.AddListener(delegate { SetVolumeFromSlider(); });
        }
    }
}