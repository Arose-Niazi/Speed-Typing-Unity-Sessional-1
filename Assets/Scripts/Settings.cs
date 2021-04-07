using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    private static float _gameVolume;
    private static string _playerName;

    public Slider volumeSetting;
    public AudioSource soundSource;

    public InputField playerNameField;

    public Text playerNameText;
    
    // Start is called before the first frame update
    void Start()
    {
        if (playerNameText != null)
        {
            playerNameText.text = _playerName;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (volumeSetting != null)
        {
            _gameVolume = volumeSetting.value;
        }
        if (playerNameField != null)
        {
            _playerName = playerNameField.text;
        }
        soundSource.volume = _gameVolume;

        if (Input.GetKeyDown("escape"))
        {
            PauseGame();
        }
        
    }
    

    public void NextScene()
    {
        SceneManager.LoadScene("GamePaly");
    }

    private void PauseGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
