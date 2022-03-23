using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
public class Win : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ItemManager collidedItem = other.GetComponent<ItemManager>();
        if (collidedItem != null && collidedItem.HasBeenPlaced)
        {
            LevelWin();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        ItemManager collidedItem = other.GetComponent<ItemManager>();
        if (collidedItem != null && collidedItem.HasBeenPlaced)
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
