using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Alphabets : MonoBehaviour
{
    private int _bestTimeMin;
    private int _bestTimeSec;

    public Text bestTime;
    public Text text;
    public Text timeField;
    private int _timeMin;
    private int _timeSec;
    private int _pos;

    private string[] keysOrder =
    {
        "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v",
        "w", "x", "y", "z"
    };
    
    // Start is called before the first frame update
    private void Start()
    {
        _bestTimeMin = PlayerPrefs.GetInt("SavedMin", 0);
        _bestTimeSec = PlayerPrefs.GetInt("SavedSec", 0);
        
        bestTime.text = $"Best Time: {_bestTimeMin:00}:{_bestTimeSec:00}";
        _timeMin = 0;
        _timeSec = 0;
        _pos = 0;
        
        InvokeRepeating(nameof(Timer), 1f, 1f);
    }

    public void Timer()
    {
        if (_pos != keysOrder.Length)
            _timeSec++;
    }
    
    
    void Update()
    {
        if (_pos == keysOrder.Length)
            return;
        if (Input.GetKeyDown(keysOrder[_pos]))
        {
            text.text = text.text.Substring(1);
            _pos++;
        }
        else
        {
            for(int i=0; i<keysOrder.Length; i++)
            {
                if (i == _pos)
                    continue;
                if(Input.GetKeyDown(keysOrder[i]))
                {
                    _timeSec += 5;
                }
            }
        }

        if (_timeSec == 60)
        {
            _timeSec = 0;
            _timeMin++;
        }

        timeField.text = $"Time: {_timeMin:00}:{_timeSec:00}";

        if (_pos == keysOrder.Length)
        {
            if (_timeMin < _bestTimeMin)
            {
                PlayerPrefs.SetInt("SavedMin", _timeMin);
                PlayerPrefs.SetInt("SavedSec", _timeSec);
            }
            else if (_timeMin == _bestTimeMin)
            {
                if (_timeSec < _bestTimeSec)
                {
                    PlayerPrefs.SetInt("SavedMin", _timeMin);
                    PlayerPrefs.SetInt("SavedSec", _timeSec);
                }
            }
            else if (_bestTimeSec == 0 && _bestTimeMin == 0)
            {
                Debug.Log("This is called Passed!");
                
                PlayerPrefs.SetInt("SavedMin", _timeMin);
                PlayerPrefs.SetInt("SavedSec", _timeSec);
            }
            PlayerPrefs.Save();
            SceneManager.LoadScene("Menu");
        }
    }
}
