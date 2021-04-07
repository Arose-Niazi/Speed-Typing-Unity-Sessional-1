using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    public InputField playerNameField;
    public GameObject errorDialog;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextScene();
        }
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void NextScene()
    {
        if(playerNameField.text.Length > 0)
            SceneManager.LoadScene("GamePaly");
        else
        {
            errorDialog.SetActive(true);
        }
    }
    
    
}
