using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Toggle _soundsToggle;
    [SerializeField] private Image _musicCheckBoxImage;
    [SerializeField] private Image _soundsCheckBoxImage;
    [SerializeField] private Sprite _checkBoxOn;
    [SerializeField] private Sprite _checkBoxOff;
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

    public void OnChangedMusic()
    {
        if (_musicToggle.isOn)
        {
            _musicCheckBoxImage.sprite = _checkBoxOn;
        }
        else
        {
            _musicCheckBoxImage.sprite = _checkBoxOff;
        }
    }

    public void OnChangedSounds()
    {
        if (_soundsToggle.isOn)
        {
            _soundsCheckBoxImage.sprite = _checkBoxOn;
        }
        else
        {
            _soundsCheckBoxImage.sprite = _checkBoxOff;
        }
    }
}
