using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ItemManager itemManager = other.GetComponent<ItemManager>();
        if (itemManager != null)
        {
            if (itemManager.HasBeenPlaced)
            {
                Score.instance.SubtractScore(itemManager.scoreValue);
            }
        }
        Destroy(other.gameObject);
    }
}
