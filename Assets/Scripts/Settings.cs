using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public static float GameVolume;
    public static string PlayerName;

    public Slider volumeSetting;
    public AudioSource soundSource;

    public InputField playerNameField;

    public Text playerNameText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (volumeSetting != null)
        {
            GameVolume = volumeSetting.value;
        }
        
        if (playerNameField != null)
        {
            PlayerName = playerNameField.text;
        }

        if (playerNameText != null)
        {
            playerNameText.text = PlayerName;
        }
        soundSource.volume = GameVolume;

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
