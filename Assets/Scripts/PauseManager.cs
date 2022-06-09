using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundsToggle;

    public bool GetMusicToglle() => _musicToggle.isOn;
    public bool GetSoundsToglle() => _soundsToggle.isOn;
    public void SetMusicToglle(bool isPlayMusic)
    {
        _musicToggle.isOn = isPlayMusic;
    }
    public void SetSoundsToglle(bool isPlaySounds)
    {
        _soundsToggle.isOn = isPlaySounds;
    }
    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
    }
    public void OnPlayButtonClick()
    {
        Time.timeScale = 1;
    }
    public void OnExitButtonClick()
    {
        Application.Quit();
    }
}
