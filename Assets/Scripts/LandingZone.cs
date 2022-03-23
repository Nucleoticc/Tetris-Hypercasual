using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingZone : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        ItemManager itemManager = other.gameObject.GetComponent<ItemManager>();
        if (itemManager != null && !itemManager.HasBeenPlaced)
        {
            itemManager.HasBeenPlaced = true;
        }
    }
}
