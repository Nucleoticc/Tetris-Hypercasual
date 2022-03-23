using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLight : MonoBehaviour
{
    [SerializeField] List<GameObject> Lights = new List<GameObject>();
    [SerializeField] float[] lightActivationDuration = new float[2];
    [SerializeField] float[] delayBetweenLights = new float[2];

    bool isLightActive = false;
    bool onDelay = false;
    float lightActivationTimer = 0f;
    float currentLightDuration = 0f;
    int currentLightIndex = 0;

    void Update()
    {
        ToggleLights();
    }

    void ToggleLights()
    {
        if (isLightActive)
        {
            lightActivationTimer += Time.deltaTime;
            if (lightActivationTimer >= currentLightDuration)
            {
                isLightActive = false;
                lightActivationTimer = 0f;
                currentLightDuration = 0f;
                Lights[currentLightIndex].SetActive(false);
                StartCoroutine(Delay());
            }
        }
        else if (!isLightActive && !onDelay)
        {
            lightActivationTimer = 0f;
            currentLightDuration = Random.Range(lightActivationDuration[0], lightActivationDuration[1]);

            currentLightIndex = Random.Range(0, Lights.Count);
            Lights[currentLightIndex].SetActive(true);

            isLightActive = true;
        }
    }

    IEnumerator Delay()
    {
        onDelay = true;
        yield return new WaitForSeconds(Random.Range(delayBetweenLights[0], delayBetweenLights[1]));
        onDelay = false;
    }
}
