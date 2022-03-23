using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    Slider loadingSlider;

    void Awake()
    {
        loadingSlider = transform.GetChild(0).GetComponent<Slider>();
    }

    void Start()
    {
        StartCoroutine(LoadLevelAsync(GameData.levelToLoadName));
    }

    IEnumerator LoadLevelAsync(string levelName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(levelName);

        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            loadingSlider.value = progress;
            yield return null;
        }
    }
}
