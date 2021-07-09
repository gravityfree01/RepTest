using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TEST_SH_Option : MonoBehaviour
{
    [SerializeField]
    public Dropdown language;
    [SerializeField]
    public Toggle sound;
    [SerializeField]
    public Toggle vibration;
    [SerializeField]
    public Toggle autosave;

    public void Save()
    {
        PlayerPrefs.SetInt("Language", language.value);
        PlayerPrefs.SetString("Sound", sound.isOn.ToString());
        PlayerPrefs.SetString("Vibration", vibration.isOn.ToString());
        PlayerPrefs.SetString("AutoSave", autosave.isOn.ToString());
    }

    public void Load()
    {
        language.value = PlayerPrefs.GetInt("Language");
        sound.isOn = bool.Parse(PlayerPrefs.GetString("Sound"));
        vibration.isOn = bool.Parse(PlayerPrefs.GetString("Vibration"));
        autosave.isOn = bool.Parse(PlayerPrefs.GetString("AutoSave"));
    }
}