using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinTimer : MonoBehaviour
{
    [SerializeField] float timeLimit = 60f;
    [SerializeField] Text timerText;

    float timeLeft;

    void Start()
    {
        timeLeft = timeLimit;
        timerText.text = "Time Left: " + timeLeft.ToString("0.0");
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        timerText.text = "Time Left: " + timeLeft.ToString("0.0");
        if (timeLeft <= 0)
        {
            LevelWin();
        }
    }

    void LevelWin()
    {
        GameData.score = Score.instance.GetScore();
        int currentSceneNumber = int.Parse(SceneManager.GetActiveScene().name);
        if (PlayerPrefs.GetInt("MaxLevelCompleted") < currentSceneNumber)
        {
            PlayerPrefs.SetInt("MaxLevelCompleted", currentSceneNumber);
        }
        PlayerPrefs.SetInt("Level", currentSceneNumber);
        SceneManager.LoadScene("LevelWin");
    }
}
