using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsHandler : MonoBehaviour
{

    void Start()
    {
        
    }

    public void ChangeGeneralVolume(Slider volumeSlider)
    {
        print("Volume changed to: " + volumeSlider.value);
        PlayerPrefs.SetInt("GeneralVolume", (int)volumeSlider.value);
        AudioManager.Instance.SetGeneralVolume();
    }
}
