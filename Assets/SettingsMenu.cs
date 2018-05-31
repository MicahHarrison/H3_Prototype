using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audio;

    public Dropdown resolutionDrop;

    Resolution[] resolutions;

    // Use this for initialization
    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDrop.ClearOptions();
        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDrop.AddOptions(options);
        resolutionDrop.value = currentResolutionIndex;
        resolutionDrop.RefreshShownValue();
    }
    public void SetResolution(int resindex)
    {
        Debug.Log(resindex);
        Resolution res = resolutions[resindex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
    
    public void SetVolume (float volume) {
        Debug.Log(volume);
        audio.SetFloat("volume", volume);
	}
    public void SetQuality(int quality)
    {
        Debug.Log(quality);
        QualitySettings.SetQualityLevel(quality);
    }
    public void SetFullScreen()
    {
        Debug.Log(Screen.fullScreen);
        Screen.fullScreen = !Screen.fullScreen;
    }

}
