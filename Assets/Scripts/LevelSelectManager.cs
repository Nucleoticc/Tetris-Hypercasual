using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] List<Button> levelButtons = new List<Button>();

    void Start()
    {
        // int MaxLevelCompleted = PlayerPrefs.GetInt("MaxLevelCompleted");
        // if (MaxLevelCompleted == 0)
        // {
        //     MaxLevelCompleted = 1;
        // }

        // for (int i = 0; i < MaxLevelCompleted; i++)
        // {
        //     levelButtons[i].interactable = true;
        // }

        for (int i = 0; i < levelButtons.Count; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    public void LoadLevel(string levelNumber)
    {
        GameData.levelToLoadName = levelNumber;
        SceneManager.LoadScene("Loading");
    }
}
