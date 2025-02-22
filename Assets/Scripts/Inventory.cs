using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Fish> fishInventory = new List<Fish>();
    public int maxFish = 20;

    private GameObject inventoryUIObject;

    public void AddFish(Fish fish)
    {
        if (fishInventory.Count < maxFish)
        {
            fishInventory.Add(fish);
        }
        else
        {
            Debug.LogWarning("Inventory is full");
        }
    }

    public void RemoveFish(Fish fish)
    {
        fishInventory.Remove(fish);
    }
}
