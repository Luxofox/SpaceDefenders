using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour {

    public Toggle fullScreenToggle;
    public Dropdown resolutionDropdown;
    public Slider volumenSlider;
    private GameSettings gameSettings;
    public AudioSource musicSource;
    public Resolution[] resolutions;

    void OnEnable()
    {
        gameSettings = new GameSettings();

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
       gameSettings.fullscreen = Screen.fullScreen = fullScreenToggle.isOn;
    }

    public void OnResolutionChange()
    {
        
    }

    public void OnVolumenChange()
    {
        musicSource.volume = gameSettings.musicVolumen = volumenSlider.value;
    }

    public void SaveSettings()
    {

    }

    public void LoadSettings()
    {

    }
}
