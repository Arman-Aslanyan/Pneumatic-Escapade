using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

//made using brackeys main menu tutorial
public class MainSettingsMenu : MonoBehaviour
{
    public AudioMixer OST;
    public AudioMixer SFX;
    public AudioMixer VC;
    public AudioMixer ESFX;
    public AudioMixer EVC;

    public TMP_Dropdown resolutionDropdown;

    public Resolution[] resolutions;

     void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && 
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetOSTVolume (float volume)
    {
        OST.SetFloat("OST", volume);
    }
    public void SetSFXVolume(float volume)
    {
        SFX.SetFloat("SFX", volume);
    }
    public void SetVCVolume(float volume)
    {
        VC.SetFloat("VC", volume);
    }
    public void SetESFXVolume(float volume)
    {
        ESFX.SetFloat("ESFX", volume);
    }
    public void SetEVCVolume(float volume)
    {
        EVC.SetFloat("EVC", volume);
    }


    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetFramerate30()
    {
        Application.targetFrameRate = 30;
    }
    public void SetFramerate60()
    {
        Application.targetFrameRate = 60;
    }
    public void SetFramerate120()
    {
        Application.targetFrameRate = 120;
    }
    public void SetFramerate240()
    {
        Application.targetFrameRate = 240;
    }
}
