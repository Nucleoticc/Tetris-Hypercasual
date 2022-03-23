using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class WinManager : MonoBehaviour
{
    [SerializeField] Text score;

    void Start()
    {
        score.text = $"Score: {GameData.score}";
    }

    public void Continue()
    {
        // int nextLevel = PlayerPrefs.GetInt("Level") + 1;
        // SceneManager.LoadScene(nextLevel);
        int nextLevel = PlayerPrefs.GetInt("Level") + 1;
        if (nextLevel > 5)
        {
            GameData.levelToLoadName = "MainMenu";
        }
        else
        {
            GameData.levelToLoadName = nextLevel.ToString();
        }
        SceneManager.LoadScene("Loading");
    }

    public void RestartLevel()
    {
        // int lastLevel = PlayerPrefs.GetInt("Level");
        // SceneManager.LoadScene(lastLevel);
        GameData.levelToLoadName = PlayerPrefs.GetInt("Level").ToString();
        SceneManager.LoadScene("Loading");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
