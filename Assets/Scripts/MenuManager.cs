using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button continueButton;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (PlayerPrefs.GetInt("Level") > 0)
        {
            continueButton.interactable = true;
        }
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void ContinueLevel()
    {
        GameData.levelToLoadName = PlayerPrefs.GetInt("Level").ToString();
        SceneManager.LoadScene("Loading");
    }
}
