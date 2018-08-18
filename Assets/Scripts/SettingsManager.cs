using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public Toggle fullScreenToggle;
    public Dropdown resolutionDropdown;
    public Slider volumenSlider;
    public AudioSource musicSource;
    public Resolution[] resolutions;

    void OnEnable()
    {
       
        fullScreenToggle.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionDropdown.onValueChanged.AddListener(delegate { OnResolutionChange(); });
        volumenSlider.onValueChanged.AddListener(delegate { OnVolumenChange(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
            {
                resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
            }
    }

    public void OnFullScreenToggle()
    {
       Screen.fullScreen = fullScreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
    }

    public void OnVolumenChange()
    {
        musicSource.volume = volumenSlider.value;
    }

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {

    }
}
