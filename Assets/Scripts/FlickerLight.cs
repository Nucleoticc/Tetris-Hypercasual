using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class FlickerLight : MonoBehaviour
{
    float final_intensity = 1.2f;
    Light2D l;
    BoxCollider2D b;

    Vector2 direction;

    void Awake()
    {
        l = GetComponent<Light2D>();
        b = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        if (transform.rotation.z == 1f)
        {
            direction = Vector2.right;
        }
        else if (transform.rotation.z == 0f)
        {
            direction = Vector2.left;
        }
    }

    void OnEnable()
    {
        b.enabled = false;
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        for (int i = 0; i < 10; i++)
        {
            l.intensity = Random.Range(0.5f, 1.5f);
            yield return new WaitForSeconds(Random.Range(0.02f, 0.08f));
        }

        l.intensity = final_intensity;
        EnableRayCast();
    }

    void EnableRayCast()
    {
        b.enabled = true;
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<ItemManager>().HasBeenPlaced)
        {
            Destroy(other.gameObject);
        }
    }
}
