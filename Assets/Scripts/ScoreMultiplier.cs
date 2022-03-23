using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    [SerializeField] int multiplier;

    private void OnTriggerStay2D(Collider2D other)
    {
        ItemManager collidedItem = other.GetComponent<ItemManager>();
        if (collidedItem != null && collidedItem.HasBeenPlaced)
        {
            Score.instance.SetMultipler(multiplier);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        ItemManager collidedItem = other.GetComponent<ItemManager>();
        if (collidedItem != null && collidedItem.HasBeenPlaced)
        {
            Score.instance.SetMultipler(1);
        }
    }
}
