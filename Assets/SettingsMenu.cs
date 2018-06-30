using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer audio;

    public Dropdown resolutionDrop;
    public Dropdown qualityDrop;
    public Slider volumeS;
    public Toggle toggle;

    Resolution[] resolutions;

    int changed = 0;

    // Use this for initialization
    void Start()
    {
        Debug.Log(changed);
        resolutions = Screen.resolutions;
        resolutionDrop.ClearOptions();
        if (GameControl.instance.isSave())
        {
            GameControl.instance.Load();
            toggle.isOn = GameControl.instance.fullScreen;
            Debug.Log("settings matched");
            volumeS.value = GameControl.instance.volume;
            audio.SetFloat("volume", GameControl.instance.volume);
            QualitySettings.SetQualityLevel(GameControl.instance.quality);
            qualityDrop.value = GameControl.instance.quality;
            qualityDrop.RefreshShownValue();
            Screen.SetResolution(GameControl.instance.reswidth, GameControl.instance.resheight, GameControl.instance.fullScreen);
        }
        else {
            Debug.Log("no save");
            GameControl.instance.reswidth = Screen.currentResolution.width;
            GameControl.instance.resheight = Screen.currentResolution.height;
        }
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
        changed++;
        Debug.Log(resindex);
        Resolution res = resolutions[resindex];
        GameControl.instance.reswidth = res.width;
        GameControl.instance.resheight = res.height;
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
   

    public void SetVolume (float volume) {
        Debug.Log(volume);
        GameControl.instance.volume = volume;
        audio.SetFloat("volume", volume);
	}
    public void SetQuality(int quality)
    {
        Debug.Log(quality);
        GameControl.instance.quality = quality;
        QualitySettings.SetQualityLevel(quality);
    }
    public void SetFullScreen()
    {
        Debug.Log(Screen.fullScreen);
        Screen.fullScreen = !Screen.fullScreen;
        GameControl.instance.fullScreen = Screen.fullScreen;
        if (Screen.fullScreen)
        {
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        else
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

}
