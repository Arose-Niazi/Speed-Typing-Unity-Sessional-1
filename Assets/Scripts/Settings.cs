using System;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private static float _gameVolume = 1f;
    private static string _playerName;

    public InputField nameInput;
    public AudioSource soundSource;
    
    public Text playerNameText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (playerNameText != null)
        {
            playerNameText.text = _playerName;
        }
        soundSource.volume = _gameVolume;
    }

    // Update is called once per frame
    

    public void VolumeChange(Single sound)
    {
        _gameVolume = sound;
        soundSource.volume = sound;
        
    }

    public void NameChange()
    {
        _playerName = nameInput.text;
    }
}
