using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject
{
    public string itemName;
    public float[] sizeRange = new float[2];
    public float valueMultiplier;
    public GameObject itemPrefab;
}